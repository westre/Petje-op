using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire.AddQuestion;

namespace PetjeOp.AddQuestionnaire
{
    public partial class AddQuestionView : UserControl
    {
        public AddQuestionDialog AddQuestionDialog { get; set; }

        public AddQuestionView()
        {
            InitializeComponent();
        }

        //Functie na klikken op 'Antwoord Toevoegen'
        private void btnAddAnswer_Click(object sender, EventArgs e)
        {
            //Als de textbox niet leeg is, antwoord toevoegen
            if (tbAnswer.Text != null)
            {
                //Voeg antwoord toe aan lijst
                clbAnswers.Items.Add(tbAnswer.Text.Trim());
                checkQuestionView();
                tbAnswer.Clear();
            }
            checkQuestionView();
        }

        public void SetQuestionDialog(AddQuestionDialog questionDialog)
        {
            this.AddQuestionDialog = questionDialog;
        }

        //Functie om antwoord te verwijderen
        private void btnDeleteAnswer_Click(object sender, EventArgs e)
        {
            //Dialoog voor bevestiging
            DialogResult dr = MessageBox.Show("Weet u zeker dat u dit antwoord wilt verwijderen?", "Let op", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            //Als er op OK geklikt is, verwijder antwoord uit lijst
            if (dr == DialogResult.Yes)
            {
                clbAnswers.Items.Remove(clbAnswers.SelectedItem);
            }

            checkQuestionView();
        }

        //Functie zodat er maar 1 checkbox aangevinkt kan worden
        private void clbAnswers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ((CheckedListBox) sender).Enabled = false;
            if (e.NewValue == CheckState.Checked)
            {
                for (int ix = 0; ix < clbAnswers.Items.Count; ++ix)
                {
                    if (e.Index != ix)
                    {
                        clbAnswers.SetItemChecked(ix, false);
                    }
                }
            }
            ((CheckedListBox)sender).Enabled = true;
            checkQuestionView();
        }

        //Knop om antwoord toe te voegen aan- en uitzetten
        private void tbAnswer_TextChanged(object sender, EventArgs e)
        {

            if (tbAnswer.Text.Count() > 0)
            {
                if (CheckIfDuplicate(tbAnswer.Text))
                {
                    btnAddAnswer.Enabled = true;
                    lblDuplicate.Text = "";
                }
                else
                {
                    btnAddAnswer.Enabled = false;
                    lblDuplicate.Text = "Geen dubbele antwoorden!";
                    Console.WriteLine("Dit werkt!");
                }
            }
            else
            {
                btnAddAnswer.Enabled = false;
                lblDuplicate.Text = "";
            }



        }

        //Valideer de ingevoerde gegevens
        public void checkQuestionView()
        {

            bool checkTwoAnswers = false;
            bool checkQuestion = false;
            bool checkCorrectAnswer = false;
            bool checkMaxAnswers = false;
            bool checkSeconds = false;
            bool checkNoDuplicates = true;

            //Check of er minimaal 2 antwoorden ingevuld zijn
            if (clbAnswers.Items.Count <= 1)
            {
                lblNonSufficientAnswers.ForeColor = Color.Red;
                lblNonSufficientAnswers.Text = "Er moeten minimaal twee antwoorden opgegeven worden!";
                checkTwoAnswers = false;
            }
            else
            {
                lblNonSufficientAnswers.Text = "";
                checkTwoAnswers = true;
            }
            
            //Check of er een vraag is ingevuld
            if (!tbQuestion.Text.Any())
            {
                lblQuestionError.ForeColor = Color.Red;
                lblQuestionError.Text = "Vul een vraag in!";
                checkQuestion = false;
            }
            else
            {
                lblQuestionError.Text = "";
                checkQuestion = true;
            }

            //Check of er een correct antwoord is geselecteerd
            if (AddQuestionDialog.addQuestionView1.clbAnswers.CheckedItems.Count != 0)
            {
                lblAnswersError.ForeColor = Color.Black;
                checkCorrectAnswer = true;
            }
            else
            {
                lblAnswersError.ForeColor = Color.Red;
                checkCorrectAnswer = false;
            }

            //Check of er meer dan 26 antwoorden ingevuld zijn
            if (AddQuestionDialog.addQuestionView1.clbAnswers.Items.Count > 26)
            {
                lblNonSufficientAnswers.ForeColor = Color.Red;
                lblNonSufficientAnswers.Text = "Er mogen maximaal 26 antwoorden gegeven worden!";
                checkMaxAnswers = false;
            }
            else
            {
                checkMaxAnswers = true;
                lblNonSufficientAnswers.Text = "";
            }

            //Check of de limiet radiobutton is gecheckt.
            if (rbLimit.Checked)
            {
                //Check of er iets in de tbSeconds tekstbox zit.
                if (tbSeconds.Text.Any())
                {
                    bool validValue = false;

                    try
                    {
                        //Kijk of het parsen van de tekstbox naar een int goed gaat.
                        int seconds = int.Parse(tbSeconds.Text);
                        validValue = true;
                    }
                    //Wanneer de inhoud geen cijfer is, exception.
                    catch (FormatException)
                    {
                        tbSeconds.Clear();
                        validValue = false;
                    }
                    //Wanneer de inhoud teveel tekens bevat, exception.
                    catch (OverflowException)
                    {
                        tbSeconds.Clear();
                        validValue = false;
                    }

                    //Wanneer de vorige checks goed zijn gegaan, hide de error. Zo niet, laat de error zien en checkSeconds is false.
                    if (validValue)
                    {
                        lblErrorSeconds.Hide();
                        checkSeconds = true;
                    }
                    else
                    {
                        lblErrorSeconds.Show();
                        checkSeconds = false;
                    }

                }
                else
                {
                    checkSeconds = false;
                }
            }
            else
            {
                checkSeconds = true;
            }

            //Zet knop 'Vraag Toevoegen' aan of uit
            if (checkTwoAnswers && checkQuestion &&
                checkCorrectAnswer && checkMaxAnswers && checkSeconds && checkNoDuplicates)
            { 
                AddQuestionDialog.btnAddQuestion.Enabled = true;
            } else
            {
                AddQuestionDialog.btnAddQuestion.Enabled = false;
            }
            
        }

        //Valideer gegevens als tekst in textbox verandert
        private void tbQuestion_TextChanged(object sender, EventArgs e)
        {
            checkQuestionView();
        }

        private void gbQuestion_Enter(object sender, EventArgs e)
        {

        }

        private void AddQuestionView_Load(object sender, EventArgs e)
        {
            lblErrorSeconds.Hide();
        }

        private void tbSeconds_TextChanged(object sender, EventArgs e)
        {
            checkQuestionView();
            rbLimit.Checked = true;
        }

        private void rbNoLimit_CheckedChanged(object sender, EventArgs e)
        {
            checkQuestionView();

            if(rbNoLimit.Checked)
                lblErrorSeconds.Hide();
        }

        private void tbAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && CheckIfDuplicate(tbAnswer.Text))
            {
                if (tbAnswer.Text.Any())
                    btnAddAnswer_Click(this, new EventArgs());
            }
        }

        private void rbLimit_CheckedChanged(object sender, EventArgs e)
        {
            checkQuestionView();
        }

        //Knop om te verwijderen van antwoord aan- en uitzetten
        private void clbAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbAnswers.SelectedIndex != -1)
            {
                btnDeleteAnswer.Enabled = true;
            }
            else
            {
                btnDeleteAnswer.Enabled = false;
            }
            checkQuestionView();
        }

        private void clbAnswers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            checkQuestionView();
        }

        public bool CheckIfDuplicate(string currentString)
        {
            currentString = currentString.Trim();

            List<string> items = new List<string>();
            foreach (object item in clbAnswers.Items)
            {
                string itemString = Convert.ToString(item);
                items.Add(itemString);
            }
            if (items.Contains(currentString))
            {
                return false;
            }
            return true;
        }
    }
}
