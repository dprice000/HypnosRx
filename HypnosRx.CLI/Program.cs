// See https://aka.ms/new-console-template for more information
using HypnosRx.Data;
using HypnosRx.Data.Models;
using HypnosRx.Resmed.Services;

const string CONNECTION_STRING = @"Data Source=C:\Users\David\Source\Repos\HypnosRx\HypnosRx\Assets\HypnosRx.db;";

ISleepRecordReader sleepRecordReader = new SleepRecordReader();
IGenericRepository<SleepSession> sessionRepo = new GenericRepository<SleepSession>(CONNECTION_STRING, "SleepSessions");

foreach(var session in sleepRecordReader.Read(@"C:\Users\David\Source\Repos\HypnosRx\HypnosRx.CLI\Assets\SLEEP_RECORD.csv"))
{
  await sessionRepo.CreateAsync(session);
}

var p = 0;