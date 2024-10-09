using starwars;

Repo repo = await Repo.CreateAsync ("https://swapi.dev/", "api/planets");
Service service = new Service(repo);
Ui ui = new Ui(service);

ui.Run();