using Async_Await_Task;

//await TeaProgram.TeaProgramMain();

await ThreadRealExampleProgram.ThreadRealExampleProgramMain();

BankAccountProgram bankAccount = new(1000);
bankAccount.Withdraw(500);

TrafficLightProgram trafficLight = new();
trafficLight.PassCar("XYZ");

LogFileWriterProgram logFileWriter = new();
logFileWriter.WriteLog("Humans are stupid");