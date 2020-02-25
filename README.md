# OneSTools.LogCfg

Библиотека для программного создания файла конфигурации технологического журнала.
Реализована с применением паттерна Fluent Interface.

Пример использования:
```c#
new LogCfgBuilder()
.UseStandartNamespace()
.Config(config =>
{
    config.Dump(dump =>
    {
        dump.Location = @"C:\DumpFolder";
        dump.Create = true;
        dump.Type = 3;
    });

    config.DefaultLog(@"C:\DefaultLogFolder", 8);

    config.Log(@"C:\LogFolder", 8, log =>
    {
        log.Event("TLOCK");
        log.Event("DBMSSQL", ev => 
            ev.Equal("p:processName", "TestDatabase"));

        log.Property("sql");
        log.Property("dbpid", prop =>
        {
            prop.Event("DBMSSQL", ev =>
            {
                ev.Equal("Usr", "АкпаевЕА");
            });
        });
    });

    config.Mem();
    config.PlanSql();
    config.Ftextupd(true);
    config.Query(true);
    config.Dbmslocks();
    config.Scriptcircrefs();
    config.System("Debug", "C", "C");
    config.Leaks(true, l =>
    {
        l.PointCall("server");
        l.PointProc("МодульУправляемогоПриложения");
        l.PointOnOff(@"ОбщийМодуль.ТестНаСервере/0", @"ОбщийМодуль.ТестНаСервере/10");
    });
})
.Build();
```
