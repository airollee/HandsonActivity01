using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ActivityOne
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo, _StudentNo;
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
            string[] ListOfGender = new string[]{
                "Female",
                "Male"
            };

            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(ListOfGender[i].ToString());
            }
        }
                /////return methods 
                public long StudentNumber(string studNum)
                {

                    _StudentNo = long.Parse(studNum);

                    return _StudentNo;
                }

                public long ContactNo(string Contact)
                {
                    if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                    {
                          _ContactNo = long.Parse(Contact);
                    }
                    else
                    {
                        throw new FormatException();
                        throw new ArgumentNullException();
                        throw new OverflowException();
                        throw new IndexOutOfRangeException();
                    }

                    return _ContactNo;
                }

                public string FullName(string LastName, string FirstName, string MiddleInitial)
                {
                    if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                    {
                        _FullName = LastName + ", " + FirstName + " " + MiddleInitial;
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }

                        return _FullName;
                }
                public int Age(string age)
                {
                        if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                        _Age = Int32.Parse(age);
                }
                        else
                {
                    throw new FormatException();
                    throw new ArgumentNullException();
                    throw new OverflowException();
                    throw new IndexOutOfRangeException();
                }

                    return _Age;
                }


        private void cbPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbPrograms.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbGender.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
            catch (ArgumentNullException ae)
            {
                MessageBox.Show(ae.Message);
            }
            catch (OverflowException oe)
            {
                MessageBox.Show(oe.Message);
            }
            catch (IndexOutOfRangeException ie)
            {
                MessageBox.Show(ie.Message);
            }
        }
    }
}