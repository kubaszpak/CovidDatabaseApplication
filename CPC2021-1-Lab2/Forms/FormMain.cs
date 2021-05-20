using CPC2020_2_Lab3.Database;
using System;
using System.Data;
using System.Windows.Forms;

namespace CPC2020_2_Lab3.Forms
{
    /// <summary>
    /// Klasa okna głównego aplikacji
    /// </summary>
    public partial class FormMain : Form
    {

        private readonly Repository _repository = new Repository();
        /// <summary>
        /// Konstruktor okna głownego aplikacji
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            //Ustawienie okna, żeby pojawiało się na środku ekranu
            StartPosition = FormStartPosition.CenterScreen;

            FetchVaccineTypeList();
            FetchDoctorsLastNameList();
            FetchLocationsNameList();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Aktualizacja danych w DataGridViewBooks przy ładowaniu okna
            RefreshDataGridViewAppointments();
        }

        /// <summary>
        /// Okienko pomocy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show(@"Użytkownik może dodać do bazy danych bezpośrednio pacjenta, szczepienie (termin szczepienie oznacza datę pracy konkretnego lekarza, który szczepi grupę pacjentów daną szczepionką w danym miejscu)
            lub bezpośrednio dodać wizytę pacjenta (termin wizyta oznacza połączęnie konkretnego pacjenta z konkretnym szczepieniem)
            - w przypadku, gdy ta opcja zostanie wybrana, w momencie, gdy w odpowiednich polach odpowiedzialnych za tworzenie pacjenta będzie zbiór danych, który nie odpowiada żadnemu pacjentowi z bazy danych, taki pacjent zostaje stworzony, sytuacja wygląda indentycznie dla pól odpowiedzialnych za tworzenie szczepienia
            Warto pamiętać, że jeśli w bazie istnieje pacjent lub szczepienie z konkretnymi danymi to polecenie dodaj pacjenta czy dodaj szczepienie nie stworzy nowego tylko zwróci Id istniejącego rekordu");
           
        }


        /// <summary>
        /// Funkcja sprawdzająca czy numer telefonu podany jako string jest odpowiedniej dlugosci i sklada sie z samych cyfr
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            if (String.IsNullOrEmpty(phoneNumber) || phoneNumber.Length > 9)
            {
                return false;
            }

            foreach (char c in phoneNumber)
            {
                if (c < '0' || c > '9')
                        return false;
            }

            return true;
        }

        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku od czyszczenia TextBoxów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearTextBoxes_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            labelLastAction.Text = "Wyczyszczono pola";
        }

        /// <summary>
        /// Metoda czyszcząca wszystkie TextBoxy w oknie głównym
        /// </summary>
        private void ClearTextBoxes()
        {
            textBoxId.Text = "";
            textBoxPatiendsFirstName.Text = "";
            textBoxPatientsLastName.Text = "";
            textBoxPhoneNumber.Text = "";
            comboBoxVaccineType.Text = "";
            comboBoxLocationName.Text = "";
            comboBoxDoctorsLastName.Text = "";
        }

        /// <summary>
        /// Metoda odświeżająca dane w dataGridViewVaccinations
        /// </summary>
        private void RefreshDataGridViewAppointments()
        {
            // pobierz wszystkie szczepienia z bazy danych
            DataTable vaccinations = _repository.GetAppointments();

            // przepisz wszytkie książki do dataGridViewVaccinations
            dataGridViewAppointments.DataSource = vaccinations;
        }

        /// <summary>
        /// Pobiera wszystkie wartości z podanej tabeli i wypełnia nimi comboBox
        /// </summary>
        private void TransferContentsOfTableToComboBox(DataTable table, ComboBox comboBox)
        {
            comboBox.BeginUpdate();

            // wyczyść listę
            comboBox.Items.Clear();

            // dodaj wszystkie elementy tabeli do comboBoxa
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    comboBox.Items.Add(row[column]);
                }
            }

            comboBox.EndUpdate();
        }

        /// <summary>
        /// Ustawia zawartość comboBoxVaccineType na pobraną z bazy danych listę rodzajów szczepionek
        /// </summary>
        private void FetchVaccineTypeList()
        {
            // pobierz całą tabelę VaccineTypes
            DataTable vaccineTypes = _repository.GetVaccineTypes();

            TransferContentsOfTableToComboBox(vaccineTypes, comboBoxVaccineType);
        }

        /// <summary>
        /// Ustawia zawartość comboBoxDoctorsLastName na pobraną z bazy danych listę znanych lekarzy, którym można przypisać nowe szczepienie
        /// </summary>
        private void FetchDoctorsLastNameList()
        {
            // pobierz całą tabelę Doctors
            DataTable doctorsNames = _repository.GetDoctorsLastNames();

            TransferContentsOfTableToComboBox(doctorsNames, comboBoxDoctorsLastName);
        }

        /// <summary>
        /// Ustawia zawartość comboBoxLocationName na pobraną z bazy danych listę dostępnych lokacji szczepień
        /// </summary>
        private void FetchLocationsNameList()
        {
            // pobierz całą tabelę Locations
            DataTable locationNames = _repository.GetLocationNames();

            TransferContentsOfTableToComboBox(locationNames, comboBoxLocationName);
        }

        /// <summary>
        /// Metoda dodająca pacjenta do bazy danych wykorzystując dane z pól tekstowych textBoxPatiendsFirstName, textBoxPatientsLastName i textBoxPhoneNumber, jeśli jeszcze taki nie istniał
        /// </summary>
        /// <returns></returns>
        private int? AddNewPatient()
        {
            string patientsFirstName = textBoxPatiendsFirstName.Text;
            string patientsLastName = textBoxPatientsLastName.Text;
            string phoneNumber = textBoxPhoneNumber.Text;
            int? resultPatient = null;

            // sprawdzenie czy podany numer telefonu nadaje sie do wpisania do bazy i sprawdzenie czy pola, które zostaną podane do zapytania do bazy danych nie są nullami

            if (IsValidPhoneNumber(phoneNumber) && !String.IsNullOrEmpty(patientsFirstName) && !String.IsNullOrEmpty(patientsLastName))
            {
                resultPatient = _repository.HandleAddNewPatient(patientsFirstName, patientsLastName, phoneNumber);
                RefreshDataGridViewAppointments();
                ClearTextBoxes();
                if (resultPatient == null)
                {
                    MessageBox.Show("Coś poszło nie tak, sprawdź poprawność wprowadzonych danych i spróbuj ponownie");
                }
            }
            else
            {
                MessageBox.Show("Niepoprawne dane w polach tekstowych: Imię pacjenta, Nazwisko pacjenta lub Numer telefonu. Pamiętaj, że numer telefonu musi być napisem o maksymalnej długości 9, składającym się z samych cyfr!");
            }

            return resultPatient;
        }

        /// <summary>
        /// Metoda dodająca pacjenta do bazy danych wykorzystując dane z pól tekstowych textBoxPatiendsFirstName, textBoxPatientsLastName i textBoxPhoneNumber, jeśli jeszcze taki nie istniał i aktualizująca labelLastAction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddPatient_Click(object sender, EventArgs e)
        {
            int? resultPatient = AddNewPatient();
            if (resultPatient != null)
            {
                labelLastAction.Text = "Dodano/wybrano pacjenta o Id - " + resultPatient;
            }
        }

        /// <summary>
        /// Metoda dodająca szczepienie do bazy danych wykorzystując dane z pól tekstowych dateTimePickerVaccinationDate, comboBoxVaccineType, comboBoxDoctorsLastName i comboBoxLocationNamem jeśli jeszcze takie nie istniało
        /// </summary>
        /// <returns></returns>
        private int? AddNewVaccination()
        {
            DateTime date = dateTimePickerVaccinationDate.Value;
            string vaccineTag = comboBoxVaccineType.Text;
            string doctorsLastName = comboBoxDoctorsLastName.Text;
            string locationName = comboBoxLocationName.Text;
            int? resultVaccination = null;

            // sprawdzenie czy pola, które zostaną podane do zapytania do bazy danych nie są nullami

            if (date != null && comboBoxVaccineType.SelectedItem != null && comboBoxDoctorsLastName.SelectedItem != null && comboBoxLocationName.SelectedItem != null)
            {
                resultVaccination = _repository.HandleAddNewVaccination(date, vaccineTag, doctorsLastName, locationName);
                RefreshDataGridViewAppointments();
                ClearTextBoxes();
                if (resultVaccination == null)
                {
                    // jesli cos poszlo nie tak w wstawianiu nowego szczepienia, odswiez wszystkie comboBoxy, przyczyną mogła być ingerencja w tabele podczas działania programu
                    FetchVaccineTypeList();
                    FetchDoctorsLastNameList();
                    FetchLocationsNameList();
                    MessageBox.Show("Coś poszło nie tak, być może dane w listach były niepoprawne, spróbuj ponownie");
                }
            }
            else
            {
                MessageBox.Show("Niepoprawne dane w polach: data, nazwisko lekarza, miejsce lub typ szczepionki!");
            }

            return resultVaccination;
        }

        /// <summary>
        /// Metoda dodająca szczepienie do bazy danych wykorzystując dane z pól tekstowych dateTimePickerVaccinationDate, comboBoxVaccineType, comboBoxDoctorsLastName i comboBoxLocationNamem jeśli jeszcze takie nie istniało i aktualizująca labelLastAction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddVaccination_Click(object sender, EventArgs e)
        {
            int? resultVaccination = AddNewVaccination();
            if (resultVaccination != null)
            {
                labelLastAction.Text = "Dodano/wybrano szczepienie o Id - " + resultVaccination;
            }
        }

        /// <summary>
        /// Metoda dodająca bezpośrednio nową wizytę do bazy danych, pobierając Id pacjenta i Id szczepienia na podstawie danych z pól tekstowych i comboBox'ów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAppointment_Click(object sender, EventArgs e)
        {
            int? resultPatient = AddNewPatient();
            int? resultVaccination = AddNewVaccination();
            if(resultVaccination != null && resultPatient != null)
            {
                _repository.HandleAddNewAppointment((int)resultPatient, (int)resultVaccination);
                RefreshDataGridViewAppointments();
                ClearTextBoxes();
                labelLastAction.Text = "Dodano wizytę";
            }
        }

        /// <summary>
        /// Metoda uzupełniająca pola tekstowe danymi z tabeli
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewAppointments_SelectionChanged(object sender, EventArgs e)
        {
            //Jeśli żadnen wiersz nie jest zaznaczony lub jest zaznaczonych więcej niż jeden to nic nie rób (return)
            int rowsCount = dataGridViewAppointments.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1)
                return;

            //weź pierwszy zaznaczony wiersz
            DataGridViewRow row = dataGridViewAppointments.SelectedRows[0];

            //wyciągnij dane z zaznaczonego wiersza
            int id = int.Parse(row.Cells[0].Value.ToString());
            DateTime date = DateTime.Parse(row.Cells[1].Value.ToString());
            string patientsFirstName = row.Cells[2].Value.ToString();
            string patientsLastName = row.Cells[3].Value.ToString();
            string phoneNumber = row.Cells[4].Value.ToString();
            string vaccineTag= row.Cells[5].Value.ToString();
            string doctorsLastName = row.Cells[7].Value.ToString();
            string locationsName = row.Cells[9].Value.ToString();

            //poustawiaj dane w textboxach wybranej książki
            textBoxId.Text = id.ToString();
            dateTimePickerVaccinationDate.Value = date;
            textBoxPatiendsFirstName.Text = patientsFirstName;
            textBoxPatientsLastName.Text = patientsLastName;
            textBoxPhoneNumber.Text = phoneNumber;

            comboBoxVaccineType.SelectedItem = vaccineTag;
            comboBoxDoctorsLastName.Text = doctorsLastName;
            comboBoxLocationName.Text = locationsName;

            labelLastAction.Text = "Wybrano wizytę";
        }

        /// <summary>
        /// Metoda aktualizująca aktualnie wybraną wizytę w bazie danych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdateAppointment_Click(object sender, EventArgs e)
        {
            //wyciągnięcie danych z textboxów
            int appointmentId = int.Parse(textBoxId.Text);
            DateTime date = DateTime.Parse(dateTimePickerVaccinationDate.Text);
            string patientsFirstName = textBoxPatiendsFirstName.Text;
            string patientsLastName = textBoxPatientsLastName.Text;
            string phoneNumber = textBoxPhoneNumber.Text;
            string vaccineTag = comboBoxVaccineType.SelectedItem.ToString();
            string doctorsLastName = comboBoxDoctorsLastName.SelectedItem.ToString();
            string locationsName = comboBoxLocationName.SelectedItem.ToString();

            if (IsValidPhoneNumber(phoneNumber) && !String.IsNullOrEmpty(patientsFirstName) && !String.IsNullOrEmpty(patientsLastName) && !String.IsNullOrEmpty(vaccineTag) && !String.IsNullOrEmpty(doctorsLastName) && !String.IsNullOrEmpty(locationsName))
            {
                //aktualizacja w bazie danych
                bool success = _repository.EditAppointment(appointmentId, date, patientsFirstName, patientsLastName, phoneNumber, vaccineTag, doctorsLastName, locationsName);

                if (success)
                {
                    RefreshDataGridViewAppointments();
                    ClearTextBoxes();
                    labelLastAction.Text = "Edytowano wizytę";
                }
                else
                {
                    labelLastAction.Text = "Coś poszło nie tak podczas edycji!";
                }

            }
            else
            {
                MessageBox.Show("Niepoprawne dane, w którymś z pól tekstowych! Pamiętaj, że numer telefonu musi być napisem o maksymalnej długości 9, składającym się z samych cyfr!");
            }
        }

        /// <summary>
        /// Metoda usuwająca wizytę z bazy danych po kliknięciu przycisku usuń wizytę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteAppointment_Click(object sender, EventArgs e)
        {
            //wyciągnięcie appointmentId z textBoxu
            int appointmentId = int.Parse(textBoxId.Text);

            //usunięcie wizyty z bazy danych
            _repository.DeleteAppointment(appointmentId);

            RefreshDataGridViewAppointments();
            ClearTextBoxes();
            labelLastAction.Text = "Usunięto wizytę";
        }
    }
}
