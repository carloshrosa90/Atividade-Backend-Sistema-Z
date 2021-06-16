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

# <h5>PROCEDURES</h5><br>

# Nome: usp_ListaRegistro<br>

USE [master]<br>
CREATE procedure [dbo].[usp_ListaRegistro]  <br>
as  <br>
begin  <br>
select l.idSeq, convert(datetime,l.dtRegistro) as dtRegistro, l.jsonLog from log  l<br>
end<br>
<br>
USE [master]<br>
alter procedure [dbo].[usp_GravarRegistro]  <br>
@jsonLog varchar(max) = null,<br>
@status varchar(max) = null<br>
as<br>
begin<br>
	update controle set status = @status where id = 'Sistema Z' <br>
	insert into log values (getdate(),@jsonLog)<br>
	select * from log<br>
end<br>
<br>
<br>
<br>
ValuesController.cs: Responsável pela gravação <br><br>

# Endpoints<br>
#POST: /api/Values<br><br>

Schemas:<br>
{<br>
date:	string nullable: true<br>
status:	string nullable: true<br>
}<br>

#  REQUEST <br>

# EXEMPLO: POST<br><br>

{<br>
	"date": "2021-05-18 10:00:00",<br>
	"status": "Sistema em TRAVANDO"<br>
}<br><br>

# RESPONSE: 200OK<br><br>

# EXEMPLO: GET<br><br>

[<br>
    {<br>
        "idSeq": 3002,<br>
        "dtRegistro": "16/06/2021 16:42:58",<br>
        "jsonLog": "{\"date\":\"2021-05-18 10:00:00\",\"status\":\"Sistema em funcionamento\"}"<br>
    },<br>
    {<br>
        "idSeq": 3003,<br>
        "dtRegistro": "16/06/2021 16:44:54",<br>
        "jsonLog": "{\"date\":\"2021-05-18 10:00:00\",\"status\":\"Sistema em funcionamento\"}"<br>
    },<br>
    {<br>
        "idSeq": 3004,<br>
        "dtRegistro": "16/06/2021 16:56:56",<br>
        "jsonLog": "{\"date\":\"2021-05-18 10:00:00\",\"status\":\"Sistema em funcionamento\"}"<br>
    },<br>
    {<br>
        "idSeq": 3005,<br>
        "dtRegistro": "16/06/2021 16:56:56",<br>
        "jsonLog": "{\"date\":\"2021-05-18 10:00:00\",\"status\":\"Sistema em funcionamento\"}"<br>
    }<br>
]<br>






