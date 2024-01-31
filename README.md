Installation
  - Het project maakt gebruik van Entity Framework, dus 'Update-Database' moet eenmaal gedraaid worden om de database op te bouwen.
  - Wanneer het project opgestart wordt voor de eerste keer wordt de data geseed die benodigd is.

Todo
  - Categorieën zouden hun eigen tabel moeten worden op dezelfde manier als SuggestionType
  - De foreign key van Suggestion naar SuggestionType klopt nog niet helemaal
  - Er moet nog een ViewModel komen voor gebruik tussen de view en controller, om alles netter uit elkaar te houden. Nu kent de View de Model en dat is niet optimaal
  - De front-end stuurt de data nog niet netjes als JSON naar de API, waardoor data op twee manieren binnenkomt in de back-end.
  - De aangeleverde JSON en het voorbeeld zijn in het nederlands. Het idee was om meerdere talen toe te laten maar dit is niet meer gelukt binnen de tijd.
