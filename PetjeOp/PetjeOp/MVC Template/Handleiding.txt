(outdated)

We gaan ervan uit dat we MainMenu willen implementeren

1. Maak de map MainMenu
2. Kopieer de klassen JOUWKLASSEController.cs, JOUWKLASSEModel.cs en JOUWKLASSEView.cs naar de map MainMenu
3. Hernoem JOUWKLASSEController.cs, JOUWKLASSEModel.cs en JOUWKLASSEView.cs naar MainMenuController.cs, MainMenuModel.cs en MainMenuView.cs respectievelijk
4. Open bestand MainMenuController.cs en verander alle JOUWKLASSEController naar MainMenuController
5. Herhaal dit voor JOUWKLASSEModel en JOUWKLASSEView
6. Check nadat je dit allemaal hebt gedaan of MainMenuView nog werkt (de designer!) en je geen enkel verwijzing hebt naar JOUWKLASSE
7. Ga naar MasterController
8. Voeg dit toe aan de constructor: Controllers.Add(new MainMenuController(this));
9. :D

Hoe kom je in de MainMenuController?

Vanuit elk willekeurig Controller:

MainMenuController mmc = MasterController.GetController(typeof(MainMenuController));
MasterController.SetController(mmc);