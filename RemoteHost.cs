public class remotehost : basesteps
{
	public void executeconditionalcommand(conditionalcommandinput input)
	{
		DI.Resolve<IRemoteHostCOntroller>().ExecuteConditionalCommand(input);
	}
	
	public void LinuxExecuteCommand(LinuxRemoteHostInput input)
	{
		DI.Resolve<IRemoteHostCOntroller>().ExecuteCommand(input);
	}
}
