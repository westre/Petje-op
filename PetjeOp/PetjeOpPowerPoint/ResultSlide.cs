using PetjeOp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace PetjeOpPowerPoint {
    public class ResultSlide {
        public class ChartData {
            public int Count { get; set; }
            public Result Result { get; set; }
        }

        public static void Add(List<Result> allResults, Question question, Microsoft.Office.Interop.PowerPoint.Slide resultSlide) {
            MultipleChoiceQuestion multipleChoiceQuestion = null;
            if (question is MultipleChoiceQuestion) {
                multipleChoiceQuestion = (MultipleChoiceQuestion)question;
            }

            // Verwijder eerst alle data
            while (resultSlide.Shapes.Count > 0) {
                resultSlide.Shapes[1].Delete();
            }
            resultSlide.Application.StartNewUndoEntry(); // preformance

            // opfleueren
            Microsoft.Office.Interop.PowerPoint.Shape resultTextBox = resultSlide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 200, 100, 500, 50);
            resultTextBox.TextFrame.TextRange.InsertAfter("Resultaten voor " + question.Description);

            // Hall alle resultaten op voor deze vraag
            List<Result> currentQuestionResults = new List<Result>();
            foreach (Result result in allResults) {
                if (result.questionID == question.ID) {
                    currentQuestionResults.Add(result);
                }
            }

            // Haal alle answeroptions op (de int)
            Dictionary<int, ChartData> distinctAnswers = new Dictionary<int, ChartData>();

            foreach (Result result in currentQuestionResults) {
                if (!distinctAnswers.ContainsKey(result.answerID)) {
                    ChartData cd = new ChartData();
                    cd.Count = 1;
                    cd.Result = result;

                    distinctAnswers.Add(result.answerID, cd);
                }
                else {
                    ChartData cd = distinctAnswers[result.answerID];
                    cd.Count++;
                }
            }

            // Pak hoogste waarde
            int highestCount = 0;
            foreach (KeyValuePair<int, ChartData> kvp in distinctAnswers) {
                if (kvp.Value.Count * 10 > highestCount)
                    highestCount = kvp.Value.Count * 10;
            }
          
            // Max breedte en hoogte voor grafiek
            int maxWidth = 400;
            int maxHeight = 300;
            
            // Calculeer breedte per staaf
            float rectPercentage = (26f - distinctAnswers.Count) / 26f; // We hebben 26 letters in het alfabet
            float rectangleWidth = (maxWidth / distinctAnswers.Count) * rectPercentage;

            // Calculeer breedte van grafiek
            float width = distinctAnswers.Count * rectangleWidth;
            float centerX = (Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Width - width) / 2;
        
            int x = (int)centerX;
            int y = 500;
            foreach (KeyValuePair<int, ChartData> kvp in distinctAnswers) {
                double percentage = (double)(10 * kvp.Value.Count) / (double)highestCount;
                double barHeight = maxHeight * percentage;

                Microsoft.Office.Interop.PowerPoint.Shape shape = resultSlide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, x, y - (int)barHeight, rectangleWidth, (int)barHeight);
                shape.Tags.Add("answer", kvp.Value.Result.answerID.ToString());

                // Zoek voor juiste answer
                if(multipleChoiceQuestion != null) {
                    foreach (Answer answer in multipleChoiceQuestion.AnswerOptions) {
                        if (answer.ID == kvp.Value.Result.answerID) {
                            resultSlide.Shapes.AddLabel(Office.MsoTextOrientation.msoTextOrientationHorizontal, x, y, 100, 100).TextEffect.Text = answer.Description;
                        }
                    }
                }            
                
                resultSlide.Shapes.AddLabel(Office.MsoTextOrientation.msoTextOrientationHorizontal, x, y - (int)barHeight, 100, 100).TextEffect.Text = "Count: " + kvp.Value.Count;

                x += (int)(rectangleWidth + 10);
            }
        }
    }
}
