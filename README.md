# Atividade-Backend-Sistema-Z
Um Sistema Z enviará para nós uma requisição POST com o status do sistema no formato JSON a cada alteração interna. Precisamos armazenar esta informação em um banco de dados SQL Server em duas tabelas por meio de Store Procedure.

<h2>Tipo do Projeto: ASP .NET CORE Web API </h2>

<h2>Ferramentas utilizadas:</h2>

1 - Visual Studio 2019;<br>
2 - Packages Manager NuGet;<br>
2.1 - Newtonsoft.Json v13.0.1;<br>
2.2 - Swashbuckle.AspNetCore v5.6.3;<br>
2.3 - System.Data.SqlClient v4.8.2;<br>
3 - Target Framework: .NET 5.0;<br>
4 - Microsoft SQL Server Management Studio 2016 (Usuário local);<br>
4.1 - Server type: Database Engine;<br>
4.1 - Usuário: (LocalDB)\MSSQLLocalDB;<br>
4.2 - Authentication: Windows Authentication;<br>
4.3 - Database: System Database/master <br>
4.4 - "connectionStrings": {"defaultConnection": "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=master;"} <br>
4.5 - Tabelas: [dbo].[log],[dbo].[controle] <br>
4.6 - Procedures: [dbo].[usp_GravarRegistro <br>

<h5>PROCEDURES</h5>

Nome: usp_ListaRegistro

USE [master]
CREATE procedure [dbo].[usp_ListaRegistro]  
as  
begin  
select l.idSeq, convert(datetime,l.dtRegistro) as dtRegistro, l.jsonLog from log  l
end

USE [master]
alter procedure [dbo].[usp_GravarRegistro]  
@jsonLog varchar(max) = null,
@status varchar(max) = null
as
begin
	update controle set status = @status where id = 'Sistema Z' 
	insert into log values (getdate(),@jsonLog)
	select * from log
end



ValuesController.cs: Responsável pela gravação <br>

<h5>Endpoints</h5>
#POST: /api/Values

Schemas:
{
date:	string nullable: true
status:	string nullable: true
}

<h5> REQUEST </h5>

EXEMPLO: POST

{
	"date": "2021-05-18 10:00:00",
	"status": "Sistema em TRAVANDO"
}

RESPONSE: 200OK

EXEMPLO: GET

[
    {
        "idSeq": 3002,
        "dtRegistro": "16/06/2021 16:42:58",
        "jsonLog": "{\"date\":\"2021-05-18 10:00:00\",\"status\":\"Sistema em funcionamento\"}"
    },
    {
        "idSeq": 3003,
        "dtRegistro": "16/06/2021 16:44:54",
        "jsonLog": "{\"date\":\"2021-05-18 10:00:00\",\"status\":\"Sistema em funcionamento\"}"
    },
    {
        "idSeq": 3004,
        "dtRegistro": "16/06/2021 16:56:56",
        "jsonLog": "{\"date\":\"2021-05-18 10:00:00\",\"status\":\"Sistema em funcionamento\"}"
    },
    {
        "idSeq": 3005,
        "dtRegistro": "16/06/2021 16:56:56",
        "jsonLog": "{\"date\":\"2021-05-18 10:00:00\",\"status\":\"Sistema em funcionamento\"}"
    }
]





