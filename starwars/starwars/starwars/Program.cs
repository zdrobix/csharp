using starwars;

Repo repo = await Repo.CreateAsync();
Service service = new Service(repo);
Ui ui = new Ui(service);

ui.Run();