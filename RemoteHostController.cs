public class RemoteHostController : IRemoteHostController
{
	private readonly IServerCommandExecutor _serverCommandExecutor;
	private readonly ITestRunner _testRunner;
	private readonly IPlaceholdersReplacer _placeholdersReplacer;
	private readonly IstringValidator _stringValodator;
	private readonly EnvSettings _envSettings;
	private readonly ICommandFactory _commandFactory;
	
	public RemoteHostController();
	
	public void ExecuteCommand(LinuxRemoteHostInput input)
	{
		var output = _serverCommandExecutor.Execute(
			
			
	}
}
