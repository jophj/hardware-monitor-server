using System.Diagnostics;

namespace HardwareMonitorService
{
    public interface IServiceManager
    {
        void CreateService();
        void DeleteService();
        void StartService();
        void StopService();
    }

    public class ServiceManager : IServiceManager
    {
        private readonly string _serviceName;
        private readonly string _binPath;

        private readonly string _createCommand = "create {0} binPath=\"{1}\" start=auto";
        private readonly string _deleteCommand = "delete {0}";

        public ServiceManager(string serviceName, string binPath)
        {
            _serviceName = serviceName;
            _binPath = binPath;
        }

        private Process BuildProcess(string command, string arguments)
        {
            Process process = new Process();
            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            return process;
        }

        public void CreateService()
        {
            Process createProcess = BuildProcess("sc", string.Format(_createCommand, _serviceName, _binPath));
            createProcess.Start();
            createProcess.WaitForExit();
        }

        public void DeleteService()
        {
            Process deleteProcess = BuildProcess("sc", string.Format(_deleteCommand, _serviceName));
            deleteProcess.Start();
            deleteProcess.WaitForExit();
        }

        public void StartService()
        {
            Process process = BuildProcess("sc", $"start {_serviceName}");
            process.Start();
            process.WaitForExit();
        }

        public void StopService()
        {
            Process process = BuildProcess("sc", $"stop {_serviceName}");
            process.Start();
            process.WaitForExit();
        }
    }
}