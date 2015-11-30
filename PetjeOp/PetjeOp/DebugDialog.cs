using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetjeOp {
    public partial class DebugDialog : Form {
        private List<Questionnaire> list;

        public DebugDialog(List<Questionnaire> list) {
            this.list = list;

            InitializeComponent();

            foreach(Questionnaire questionnaire in list) {
                TreeNode questionnaireTreeNode = treeView1.Nodes.Add(questionnaire.Name);
                foreach(MultipleChoiceQuestion question in questionnaire.Questions) {
                    TreeNode questionTreeNode = questionnaireTreeNode.Nodes.Add(question.Description);
                    foreach(Answer answer in question.AnswerOptions) {
                        if(answer.ID == question.CorrectAnswer.ID) {
                            questionTreeNode.Nodes.Add("CORRECTANSWER: " + question.CorrectAnswer.Description);
                        }
                        else {
                            questionTreeNode.Nodes.Add(answer.Description);
                        }      
                    }                
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
