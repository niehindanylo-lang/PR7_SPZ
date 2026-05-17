using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        private List<Person> peopleList = new List<Person>();

        private TextBox tbFirstName;
        private TextBox tbLastName;
        private TextBox tbBirthYear;
        private TextBox tbWeight;
        private TextBox tbHeight;
        private CheckBox chbIsStudent;
        private CheckBox chbHasLicense;
        private Button btnAddPerson;
        private Button btnClear;
        private RichTextBox rtbOutput;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblBirthYear;
        private Label lblWeight;
        private Label lblHeight;

        public Form1()
        {
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.tbFirstName = new TextBox() { Location = new Point(130, 20), Size = new Size(150, 20) };
            this.tbLastName = new TextBox() { Location = new Point(130, 55), Size = new Size(150, 20) };
            this.tbBirthYear = new TextBox() { Location = new Point(130, 90), Size = new Size(150, 20) };
            this.tbWeight = new TextBox() { Location = new Point(130, 125), Size = new Size(150, 20) };
            this.tbHeight = new TextBox() { Location = new Point(130, 160), Size = new Size(150, 20) };

            this.chbIsStudent = new CheckBox() { Location = new Point(25, 200), Size = new Size(90, 20), Text = "Студент" };
            this.chbHasLicense = new CheckBox() { Location = new Point(130, 200), Size = new Size(150, 20), Text = "Водійські права" };

            this.btnAddPerson = new Button() { Location = new Point(25, 235), Size = new Size(110, 30), Text = "Додати" };
            this.btnClear = new Button() { Location = new Point(170, 235), Size = new Size(110, 30), Text = "Очистити" };

            this.rtbOutput = new RichTextBox() { Location = new Point(300, 20), Size = new Size(320, 245) };

            this.lblFirstName = new Label() { Location = new Point(25, 23), Size = new Size(100, 20), Text = "Ім'я:" };
            this.lblLastName = new Label() { Location = new Point(25, 58), Size = new Size(100, 20), Text = "Прізвище:" };
            this.lblBirthYear = new Label() { Location = new Point(25, 93), Size = new Size(100, 20), Text = "Рік народження:" };
            this.lblWeight = new Label() { Location = new Point(25, 128), Size = new Size(100, 20), Text = "Вага (кг):" };
            this.lblHeight = new Label() { Location = new Point(25, 163), Size = new Size(100, 20), Text = "Ріст (м):" };

            this.btnAddPerson.Click += new EventHandler(this.btnAddPerson_Click);
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            this.ClientSize = new Size(644, 291);
            this.Controls.AddRange(new Control[] {
                tbFirstName, tbLastName, tbBirthYear, tbWeight, tbHeight,
                chbIsStudent, chbHasLicense, btnAddPerson, btnClear, rtbOutput,
                lblFirstName, lblLastName, lblBirthYear, lblWeight, lblHeight
            });

            this.Name = "Form1";
            this.Text = "Лабораторна робота 13";
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            try
            {
                Person p = new Person
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    BirthYear = int.Parse(tbBirthYear.Text),
                    Weight = double.Parse(tbWeight.Text),
                    Height = double.Parse(tbHeight.Text),
                    IsStudent = chbIsStudent.Checked,
                    HasDriverLicense = chbHasLicense.Checked
                };

                peopleList.Add(p);
                UpdateOutput();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка введення даних: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOutput()
        {
            rtbOutput.Clear();
            rtbOutput.AppendText("РЕЗУЛЬТАТИ ОБРОБКИ МАСИВУ:\r\n");

            foreach (var p in peopleList)
            {
                rtbOutput.AppendText($"\r\nПерсона: {p.FirstName} {p.LastName}\r\n");
                rtbOutput.AppendText($"Вік: {p.Age} років\r\n");
                rtbOutput.AppendText($"Індекс маси тіла (ІМТ): {p.GetBMI():F2}\r\n");
                rtbOutput.AppendText(p.IsStudent ? "Статус: Студент\r\n" : "Статус: Не студент\r\n");
                rtbOutput.AppendText(p.HasDriverLicense ? "Водій: Так\r\n" : "Водій: Ні\r\n");
                rtbOutput.AppendText("-------------------------------------------\r\n");
            }
        }

        private void ClearInputs()
        {
            tbFirstName.Clear();
            tbLastName.Clear();
            tbBirthYear.Clear();
            tbWeight.Clear();
            tbHeight.Clear();
            chbIsStudent.Checked = false;
            chbHasLicense.Checked = false;
            tbFirstName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            peopleList.Clear();
            rtbOutput.Clear();
            ClearInputs();
        }
    }
}