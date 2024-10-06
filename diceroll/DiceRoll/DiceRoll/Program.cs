using DiceRoll;

Repo repo = new Repo();
Service service = new Service(repo);
Ui ui = new Ui(service);

ui.run();

