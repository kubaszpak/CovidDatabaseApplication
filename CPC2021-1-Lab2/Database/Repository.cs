using System;
using System.Data;
using System.Data.SqlClient;

namespace CPC2020_2_Lab3.Database
{
    /// <summary>
    /// Klasa abstrakcyjna mająca zmienne i/lub metody, które każde repozytorium powinno zawierać
    /// </summary>
    public class Repository
    {

        /// <summary>
        /// ConnectionString z właściwości służący do łączenia się z bazą danych
        /// </summary>
        private readonly SqlConnection _connection = new SqlConnection(Properties.Resources.ConnectionString);

        /// <summary>
        /// Metoda zwracająca wszystkie wizyty z tabeli Appointments z dodatkowymi informacjami z innych tabel
        /// </summary>
        /// <returns></returns>
        public DataTable GetAppointments()
        {
            string query = @"SELECT Appointments.Id, Vaccinations.Date as 'Data', Patients.FirstName as 'Imię', Patients.LastName as 'Nazwisko', Patients.PhoneNumber as 'Nr telefonu', VaccineTypes.Tag as 'Szczepionka', Patients.ReceivedFirstDose as 'Po pierwszej dawce', Doctors.LastName as 'Nazwisko doktora', MedicalTitles.Name as 'Tytul doktora', Locations.Name as 'Miejsce', Regions.Name as 'Region'
            FROM Appointments 
            JOIN Vaccinations ON Appointments.VaccinationId = Vaccinations.Id
            JOIN Patients ON Appointments.PatientId = Patients.Id
            JOIN VaccineTypes ON VaccineTypes.Id = Vaccinations.VaccineTypeId
            JOIN Locations ON Locations.Id = Vaccinations.LocationId
            JOIN Regions ON Regions.Id = Locations.RegionId
            JOIN Doctors ON Doctors.Id = Vaccinations.DoctorId
            JOIN MedicalTitles ON MedicalTitles.Id = Doctors.MedicalTitleId;";
            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Pobiera tabelę z bazy danych wykonując zadane query
        /// </summary>
        /// <returns></returns>
        private DataTable GetTableFromQuery(string query)
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Metoda pobierająca tabelę z rodzajami szczepionek z bazy danych
        /// </summary>
        /// <returns></returns>
        public DataTable GetVaccineTypes()
        {
            string query = @"SELECT VaccineTypes.Tag
            FROM VaccineTypes; ";
            return GetTableFromQuery(query);

        }

        /// <summary>
        /// Metoda pobierająca tabelę z nazwiskami lekarzy z bazy danych
        /// </summary>
        /// <returns></returns>
        public DataTable GetDoctorsLastNames()
        {
            string query = @"SELECT Doctors.LastName 
            FROM Doctors;";
            return GetTableFromQuery(query);
        }

        /// <summary>
        /// Metoda pobierająca tabelę z nazwami lokacji szczepień z bazy danych
        /// </summary>
        /// <returns></returns>
        public DataTable GetLocationNames()
        {
            string query = @"SELECT Locations.Name 
            FROM Locations;";
            return GetTableFromQuery(query);
        }

        /// <summary>
        /// Metoda wykonująca polecenia SQL sprawdzające czy w bazie istnieje pacjent z określonymi danymi, dodające nowego pacjenta do tabeli Patients, jeśli nie go jeszcze w tabeli i zwracająca jego Id
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public int? HandleAddNewPatient(string firstName, string lastName, string phoneNumber)
        {
            // query do pobrania Id pacjenta, TOP 1 w razie gdyby bylo dwoch spelniajacych zapytanie zwroci Id pierwszego
            string queryGetPatientsId = @"SELECT TOP 1 Id
            FROM Patients
            WHERE FirstName = '" + firstName + "' AND LastName = '" + lastName + "' AND PhoneNumber = '" + phoneNumber + "';";

            _connection.Open();

            // pobierz id pacjenta z zadanymi danymi
            SqlCommand commandGetPatientsId = new SqlCommand(queryGetPatientsId, _connection);
            int? patientsId = (int?)commandGetPatientsId.ExecuteScalar();

            // jeśli nie nie ma pacjenta z takimi danymi to dodaj nowego
            if (patientsId == null)
            {
                // dodanie nowego pacjenta do bazy danych
                string insertPatientQuery = "INSERT INTO Patients VALUES ('" + firstName + "','" + lastName + "','" + phoneNumber + "', 0);";
                SqlCommand commandInsertPatient = new SqlCommand(insertPatientQuery, _connection);
                commandInsertPatient.ExecuteNonQuery();

                // pobranie z bazy danych id nowo dodanego pacjenta
                // commandGetPatientsId = new SqlCommand(queryGetPatientsId, _connection);
                patientsId = (int?)commandGetPatientsId.ExecuteScalar();
            }

            _connection.Close();

            return patientsId;
        }

        /// <summary>
        /// Metoda wykonująca polecenia SQL sprawdzające czy w bazie znajduje się już szczepienie z określonymi danymi, dodające nowy termin szczepienia do tabeli Vaccinations, jeśli nie go jeszcze w tabeli i zwracająca jego Id
        /// </summary>
        /// <param name="date"></param>
        /// <param name="locationId"></param>
        /// <param name="vaccineTypeId"></param>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public int? HandleAddNewVaccination(DateTime date, string vaccineTag, string doctorsLastName, string locationName)
        {
            // query do pobrania Id szczepienie zakladajac ze nie bedzie dwoch spelniajacych rekordów, w tym wypadku dodane TOP 1 zeby zwrocic pierwszy
            string queryGetVaccinationId = @"SELECT TOP 1 Id
            FROM Vaccinations
            WHERE Date = @date
            AND LocationId = (SELECT TOP 1 Id FROM Locations WHERE Name = @locationName)
            AND VaccineTypeId = (SELECT TOP 1 Id FROM VaccineTypes WHERE Tag = @vaccineTag)
            AND DoctorId = (SELECT TOP 1 Id FROM Doctors WHERE LastName = @doctorsLastName);";

            _connection.Open();

            SqlParameter vaccinationDateParameter = new SqlParameter("@date", SqlDbType.DateTime);
            vaccinationDateParameter.Value = date;

            // pobierz id szczepienia z zadanymi danymi
            SqlCommand commandGetVaccinationId = new SqlCommand(queryGetVaccinationId, _connection);
            commandGetVaccinationId.Parameters.Add(vaccinationDateParameter);
            commandGetVaccinationId.Parameters.AddWithValue("@locationName", locationName);
            commandGetVaccinationId.Parameters.AddWithValue("@vaccineTag", vaccineTag);
            commandGetVaccinationId.Parameters.AddWithValue("@doctorsLastName", doctorsLastName);
            int? vaccinationId = (int?)commandGetVaccinationId.ExecuteScalar();

            // jeśli nie nie ma szczepienia z określonymi danymi to dodaj nowego
            if (vaccinationId == null)
            {
                // dodanie nowego terminu do bazy danych
                string insertPatientQuery = @"INSERT INTO Vaccinations VALUES (@date,
                (SELECT TOP 1 Id FROM Locations WHERE Name = @locationName),
                (SELECT TOP 1 Id FROM VaccineTypes WHERE Tag = @vaccineTag), 
                (SELECT TOP 1 Id FROM Doctors WHERE LastName = @doctorsLastName));";
                SqlCommand commandInsertPatient = new SqlCommand(insertPatientQuery, _connection);

                SqlParameter vaccinationInsertDateParameter = new SqlParameter("@date", SqlDbType.DateTime);
                vaccinationInsertDateParameter.Value = date; 
                
                commandInsertPatient.Parameters.Add(vaccinationInsertDateParameter);
                commandInsertPatient.Parameters.AddWithValue("@locationName", locationName);
                commandInsertPatient.Parameters.AddWithValue("@vaccineTag", vaccineTag);
                commandInsertPatient.Parameters.AddWithValue("@doctorsLastName", doctorsLastName);
                commandInsertPatient.ExecuteNonQuery();

                // pobranie z bazy danych id nowo dodanego terminu
                vaccinationId = (int?)commandGetVaccinationId.ExecuteScalar();
            }

            _connection.Close();

            return vaccinationId;
        }

        /// <summary>
        /// Metoda wykonująca polecenie SQL dodające nowy rekord do tabeli Appointments
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="vaccinationId"></param>
        /// <returns></returns>
        public void HandleAddNewAppointment(int patientId, int vaccinationId)
        {

            _connection.Open();

            string insertAppointmentQuery = "INSERT INTO Appointments VALUES (" + vaccinationId + ","+ patientId +");";
            SqlCommand commandInsertAppointment = new SqlCommand(insertAppointmentQuery, _connection);
            commandInsertAppointment.ExecuteNonQuery();

            _connection.Close();
        }

        /// <summary>
        /// Metoda edytująca w bazie danych za pomocą SQL query wizyty z tabeli Appointments
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="date"></param>
        /// <param name="patientsFirstName"></param>
        /// <param name="patientsLastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="vaccineTag"></param>
        /// <param name="doctorsLastName"></param>
        /// <param name="locationsName"></param>
        /// <returns></returns>
        public bool EditAppointment(int appointmentId, DateTime date, string patientsFirstName, string patientsLastName, string phoneNumber, string vaccineTag, string doctorsLastName, string locationsName)
        {
            // ponowne użycie metody służącej do pobrania z bazy, Id pacjenta, którego dane zgadzają się z danymi zadanymi przez użytkownika
            // w przypadku gdy żaden pacjent nie spełnia oczekiwań, metoda tworzy nowego pacjenta w bazie i zwraca jego Id
            int? resultPatientId = HandleAddNewPatient(patientsFirstName, patientsLastName, phoneNumber);
            // ponowne użycie metody służącej do pobrania z bazy, Id szczepienia, którego dane zgadzają się z danymi zadanymi przez użytkownika
            // w przypadku gdy żadne szczepienie nie spełnia oczekiwań, metoda tworzy nowe szczepienie w bazie i zwraca jego Id
            int? resultVaccinationId = HandleAddNewVaccination(date, vaccineTag, doctorsLastName, locationsName);

            if (resultPatientId != null && resultVaccinationId != null)
            {
                _connection.Open();

                string updateAppointmentQuery = "UPDATE Appointments SET VaccinationId = " + (int)resultVaccinationId + ", PatientId = " + (int)resultPatientId + " WHERE Id=" + appointmentId + ";";
                SqlCommand commandInsertAppointment = new SqlCommand(updateAppointmentQuery, _connection);
                commandInsertAppointment.ExecuteNonQuery();

                _connection.Close();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Metoda usuwająca wizytę o zadanym Id
        /// </summary>
        /// <param name="appointmentId"></param>
        public void DeleteAppointment(int appointmentId)
        {
            string queryDeleteAppointment = "DELETE FROM Appointments WHERE Id = " + appointmentId + ";";

            _connection.Open();

            SqlCommand commandDeleteAppointment = new SqlCommand(queryDeleteAppointment, _connection);
            commandDeleteAppointment.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
