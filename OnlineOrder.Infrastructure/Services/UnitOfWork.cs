using Microsoft.Data.SqlClient;
using OnlineOrder.Infrastructure.Interfaces;

namespace OnlineOrder.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly IHttpSession _session;

    private SqlConnection? _connection;
    
    public UnitOfWork(IHttpSession session)
    {
        _session = session;
    }

    public async Task Login(CancellationToken cancellationToken = default)
    {
        //In case needed to open the session to database we can get the info from HttpSession
        //Instead using a SqlConnection will inject a factory of connections
        //The goal is authenticate and open a session once on the startup middleware pipeline with the sql server.
        //Then in the repositories just open connections within the correspondent Unit Of Work scope
        var connString = "Server=127.0.0.1,1433\\SQLEXPRESS;Initial Catalog=OnlineOrderDB;Persist Security Info=False;User ID=app;Password=admin;Connection Timeout=30;Integrated Security=True;TrustServerCertificate=True;Pooling=False";
        _connection = new SqlConnection(connString);

        await _connection.OpenAsync(cancellationToken);
    }
}