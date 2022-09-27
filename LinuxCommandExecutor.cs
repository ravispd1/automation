public class LinuxCommandExecutor : ICommandExecutor
{
	private readonly ITestRunner _runner;
	private const string TerminalName = ""vt100;
	private const int Columns = 255;
	private const int Rows = 50;
	private const int Width = 800;
	private const int Height = 600;
	private const int BufferSize = 1024;
	
	public LinuxCommandExecutor(ITestRunner runner)
	{
		_runner = runner;
	}
	
	public string Execute(string host, string username, string password, string appId, string command)
	{
		var regex = CreateTerminalPromptRegex(host);
		return Execute(host, username, password, appId, command, regex);
	}
	
	public string Execute(string host, string username, string password, string appId, string command, string stopRegex)
	{
		var regex = CreateTerminalPromptRegex(stopRegex);
		return Execute(host, username, password, appId, command, regex);
	}
	
	public string Execute(string host, string username, string password, string appId, string command, Regex stopRegex)
	{
		LogInputParams(host, username, appId, command);
		
		using (var client = new SshClient(host, username, password))
		{
			try
			{
				client.Connect();
				var sb = new StringBuilder();
				var modes = new Dictionary<TerminalModes, unit>();
				var promptRegex = CreateTerminalPromptRegex(host);
				using (var stream = client.CreateShellStream(TerminalName, Columns, Rows, Width, Height, BufferSize, modes))
				{
					sb.Append(stream.Expect(promptRegex));
					if(appId != null)
					{
						stream.Write($"-k su - {appId}\n");
						stream.Expect($"password for {username}:");
						stream.Write($"{password}\n");
						sb.Append(stream.Expect(promptRegex));
						
					}
					stream.Write($"{command}\n");
					
					var latestRead = string.Empty;
				}
			}
		}
	}
}
