using PetjeOp;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        // Functie voor het toevoegen van gegevens op een result slide
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
                if(result.answerID != null) {
                    if (!distinctAnswers.ContainsKey(result.answerID.Value)) {
                        ChartData cd = new ChartData();
                        cd.Count = 1;
                        cd.Result = result;

                        distinctAnswers.Add(result.answerID.Value, cd);
                    }
                    else {
                        ChartData cd = distinctAnswers[result.answerID.Value];
                        cd.Count++;
                    }
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
            int maxHeight = 275;

            // Calculeer breedte per staaf
            float rectangleWidth = 0;
            float rectPercentage = (26f - distinctAnswers.Count) / 26f; // We hebben 26 letters in het alfabet
            if(distinctAnswers.Count > 0) {
                rectangleWidth = (maxWidth / distinctAnswers.Count) * rectPercentage;
            }

            // Calculeer breedte van grafiek voor het centeren
            float width = distinctAnswers.Count * rectangleWidth;
            float centerX = (Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Width - width) / 2;

            // Calculeer breedte van staaf voor het centeren van labels
            float centerLabelPosition = rectangleWidth / 2;
        
            int x = (int)centerX;
            int y = 400;
            foreach (KeyValuePair<int, ChartData> kvp in distinctAnswers) {
                double percentage = (double)(10 * kvp.Value.Count) / (double)highestCount;
                double barHeight = maxHeight * percentage;

                Microsoft.Office.Interop.PowerPoint.Shape shape = resultSlide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, x, y - (int)barHeight, rectangleWidth, (int)barHeight);
                shape.Tags.Add("answer", kvp.Value.Result.answerID.ToString());

                // Correct answer? Maak het een ander kleurtje
                if(question.CorrectAnswer != null && kvp.Key == question.CorrectAnswer.ID) {
                    shape.Fill.ForeColor.RGB = ColorTranslator.ToOle(Color.ForestGreen);
                }

                // Zoek voor juiste answer
                if(multipleChoiceQuestion != null) {
                    foreach (Answer answer in multipleChoiceQuestion.AnswerOptions) {
                        // Answer gevonden, is tevens geen correct answer
                        if (answer.ID == kvp.Value.Result.answerID && question.CorrectAnswer.ID != answer.ID) {
                            //int offset = answer.Description.Length * 5;
                            int offset = 0;
                            // Aantal karakters minder dan 10, geef het horizontaal weer
                            if (answer.Description.Length <= 10)
                                resultSlide.Shapes.AddLabel(Office.MsoTextOrientation.msoTextOrientationHorizontal, x + centerLabelPosition - offset, y, 100, 100).TextEffect.Text = answer.Description;
                            else {
                                // Meer dan 10 karakters, geef het diagonaal weer
                                Microsoft.Office.Interop.PowerPoint.Shape labelShape = resultSlide.Shapes.AddLabel(Office.MsoTextOrientation.msoTextOrientationDownward, x + centerLabelPosition - offset, y, 100, 100);
                                labelShape.TextEffect.Text = answer.Description;
                                labelShape.Rotation = 315f;
                            }
                        }
                        // Answer gevonden, is tevens correct answer
                        else if (answer.ID == kvp.Value.Result.answerID && question.CorrectAnswer.ID == answer.ID) {
                            int offset = 0;
                            // Aantal karakters minder dan 10, geef het horizontaal weer
                            if (question.CorrectAnswer.Description.Length <= 10)
                                resultSlide.Shapes.AddLabel(Office.MsoTextOrientation.msoTextOrientationHorizontal, x + centerLabelPosition - offset, y, 100, 100).TextEffect.Text = answer.Description;
                            else {
                                // Meer dan 10 karakters, geef het diagonaal weer
                                Microsoft.Office.Interop.PowerPoint.Shape labelShape = resultSlide.Shapes.AddLabel(Office.MsoTextOrientation.msoTextOrientationDownward, x + centerLabelPosition - offset, y, 100, 100);
                                labelShape.TextEffect.Text = question.CorrectAnswer.Description;
                                labelShape.Rotation = 315f;
                            }
                        }
                    }
                }

                // Answer label
                Microsoft.Office.Interop.PowerPoint.Shape label = resultSlide.Shapes.AddLabel(Office.MsoTextOrientation.msoTextOrientationHorizontal, x + centerLabelPosition - 10, y - (int)barHeight, 100, 100);
                label.TextEffect.Text = kvp.Value.Count.ToString();
                label.TextFrame.TextRange.Font.Color.RGB = Color.White.ToArgb();

                x += (int)(rectangleWidth + 10);
            }
        }
    }
}
