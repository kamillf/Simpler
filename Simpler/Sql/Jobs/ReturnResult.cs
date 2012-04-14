﻿namespace Simpler.Sql.Jobs
{
    public class ReturnResult : InOutJob<ReturnResult.In, ReturnResult.Out>
    {
        public class In
        {
            public string ConnectionName { get; set; }
            public string Sql { get; set; }
            public object Values { get; set; }
        }

        public class Out
        {
            public int RowsAffected { get; set; }
        }

        public _RunSqlAction RunSqlAction { get; set; }

        public override void Run()
        {
            RunSqlAction.ConnectionName = _In.ConnectionName;
            RunSqlAction.Sql = _In.Sql;
            RunSqlAction.Values = _In.Values;
            RunSqlAction.CommandAction =
                command =>
                {
                    _Out = new Out {RowsAffected = command.ExecuteNonQuery()};
                };
            RunSqlAction.Run();
        }
    }
}