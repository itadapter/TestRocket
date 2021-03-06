﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Mime;
using DapperApi.Model;

namespace DapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoNameController : ControllerBase
    {

    /// <summary>
    /// Does some fake stuff
    /// </summary>
    /// <returns>some data</returns>
    [HttpGet]
    [Produces("application/json")]
    public async Task Get()
    {
      Response.ContentType = "application/json; charset=utf-8";

      //var syncIOFeature = HttpContext.Features.Get<IHttpBodyControlFeature>();
      //if (syncIOFeature != null)
      //{
      //  syncIOFeature.AllowSynchronousIO = true;
      //}

      using var db = new SqlConnection(ApiConstants.MASTER_REF_CONNECT_STRING);

      var QUERY =
@"
SELECT TOP 100 [PostalCode]
      ,[PlaceName]
      ,[AdminName1]
      ,[AdminCode1]
      ,[AdminName2]
      ,[AdminCode2]
      ,[Latitude]
      ,[Longitude]
      ,[Accuracy]
FROM [dbo].[USGeoName]
FOR JSON PATH
";
      Response.ContentType = MediaTypeNames.Application.Json;
      await db.QueryAsyncInto(Response.Body, QUERY, buffered: false);
      //await Task.Run(() =>
      // {
      //   db.QueryInto(Response.Body, QUERY);
      // });
    }

    [HttpGet("geojson")]
    [Produces("application/json")]
    public async Task GetGeoJson()
    {
      Response.ContentType = "application/json; charset=utf-8";
      using var qe = new SqlJsonQueryStreamWriter(ApiConstants.MASTER_REF_CONNECT_STRING);
      var query =
@"
SELECT TOP 1000 [PostalCode]
      ,[PlaceName]
      ,[AdminName1]
      ,[AdminCode1]
      ,[AdminName2]
      ,[AdminCode2]
      ,[Latitude]
      ,[Longitude]
      ,[Accuracy]
FROM [dbo].[USGeoName]
";

      var ms = await qe.ExecuteJsonQueryAsync(query) as MemoryStream;
      await Response.Body.WriteAsync(ms.ToArray(), 0, (int)ms.Length);

      // https://localhost:5001/api/geoname/geojson
    }

    [HttpPost("geojson")]
    [Produces("application/json")]
    public async Task PostGeoJson(QueryCommandOption queryOption)
    {
      Response.ContentType = "application/json; charset=utf-8";
      using var qe = new SqlJsonQueryStreamWriter(ApiConstants.MASTER_REF_CONNECT_STRING);
//      var query =
//@"
//SELECT TOP 1000 [PostalCode]
//      ,[PlaceName]
//      ,[AdminName1]
//      ,[AdminCode1]
//      ,[AdminName2]
//      ,[AdminCode2]
//      ,[Latitude]
//      ,[Longitude]
//      ,[Accuracy]
//FROM [dbo].[USGeoName]
//";


      var ms = await qe.ExecuteJsonQueryAsync(queryOption) as MemoryStream;
      await Response.Body.WriteAsync(ms.ToArray(), 0, (int)ms.Length);

      // https://localhost:5001/api/geoname/geojson
    }

    [HttpGet("query")]
    [ProducesDefaultResponseType(typeof(IEnumerable<Geo>))]
    [ProducesResponseType(typeof(IEnumerable<Geo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IEnumerable<Geo>> QueryGeoName()
    {
      using var db = new SqlConnection(ApiConstants.MASTER_REF_CONNECT_STRING);

      var QUERY =
@"
SELECT TOP 1000 [PostalCode]
      ,[PlaceName]
      ,[AdminName1]
      ,[AdminCode1]
      ,[AdminName2]
      ,[AdminCode2]
      ,[Latitude]
      ,[Longitude]
      ,[Accuracy]
FROM [dbo].[USGeoName]
";
      //var data = await db.QueryAsync(QUERY);
      //return new OkObjectResult((await db.QueryAsync(QUERY)).Select(x => new {x.PostalCode, x.PlaceName, x.AdminName1, x.AdminCode1, x.AdminName2, x.AdminCode2, x.Latitude, x.Longitude, x.Accuracy }));
      return await db.QueryAsync<Geo>(QUERY).ConfigureAwait(false);
      //return new OkObjectResult(data.Select(x=> (JObject)x));
    }

    [HttpGet("pipe")]
    [ProducesDefaultResponseType(typeof(QueryResults[]))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(QueryResults[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServerError), StatusCodes.Status500InternalServerError)]
    public async Task GetPipeContent()
    {
      Response.ContentType = "application/json; charset=utf-8";
      QueryExecutor qe = new QueryExecutor();
      var query =
@"
SELECT TOP (1000) [AccessFailedCount]
      ,[UserName]
      ,[PasswordHash]
      ,[PasswordExpiration]
      ,[ConcurrencyStamp]
      ,[IsBlocked]
      ,[IsDeleted]
      ,[LockoutEnabled]
      ,[LockoutEnd]
      ,[SecurityStamp]
      ,[Data]
      ,[ModifiedBy]
      ,[ModifiedDate]
  FROM [dbo].[UserAuthentication]
";
      Response.ContentType = MediaTypeNames.Application.Json;
      var ms = await qe.ExecuteJsonQueryAsync(query) as MemoryStream;
      await Response.Body.WriteAsync(ms.ToArray(), 0, (int)ms.Length);


      //byte[] buffer = Encoding.Default.GetBytes("Hello World");
      //await Response.Body.WriteAsync(buffer, 0, buffer.Length);

      // https://localhost:5001/api/geoname/pipe
    }

    [HttpGet("json")]
    [ProducesDefaultResponseType(typeof(QueryResults[]))]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task GetJsonContent()
    {
      Response.ContentType = "application/json; charset=utf-8";
      using var qe = new SqlJsonQueryStreamWriter(ApiConstants.TEST_CONNECT_STRING);
      var query =
@"
SELECT TOP (1000) [AccessFailedCount]
      ,[UserName]
      ,[PasswordHash]
      ,[PasswordExpiration]
      ,[ConcurrencyStamp]
      ,[IsBlocked]
      ,[IsDeleted]
      ,[LockoutEnabled]
      ,[LockoutEnd]
      ,[SecurityStamp]
      ,[Data]
      ,[ModifiedBy]
      ,[ModifiedDate]
  FROM [dbo].[UserAuthentication]
";
      Response.ContentType = MediaTypeNames.Application.Json;
      var ms = await qe.ExecuteJsonQueryAsync(query) as MemoryStream;
      await Response.Body.WriteAsync(ms.ToArray(), 0, (int)ms.Length);

      // https://localhost:5001/api/geoname/json
    }

  }

  public class Geo
  {
    public int PostalCode { get; set; }
    public string PlaceName { get; set; }
    public string AdminName1 { get; set; }
    public string AdminCode1 { get; set; }
    public string AdminName2 { get; set; }
    public string AdminCode2 { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public byte? Accuracy { get; set; }
  }
}

// Some fake objects for swagger to show


public class QueryResults
{
  IEnumerable<DataRow> Rows { get; set; }
}

public class DataRow
{
  public object Value { get; set; }
}

/// <summary>
/// Something bad happened and this is why
/// </summary>
public class ServerError
{
  /// <summary>
  /// Error Code Number
  /// </summary>
  public int ErrorCode { get; set; }

  /// <summary>
  /// What you did wrong
  /// </summary>
  public string Message { get; set; }

  /// <summary>
  /// Way to keep in sync
  /// </summary>
  public Guid CorrelationId { get; set; }
}

// or do this in ConfigureServices

//public void ConfigureServices(IServiceCollection services)
//{
//  // If using Kestrel:
//  services.Configure<KestrelServerOptions>(options =>
//  {
//    options.AllowSynchronousIO = true;
//  });

//  // If using IIS:
//  services.Configure<IISServerOptions>(options =>
//  {
//    options.AllowSynchronousIO = true;
//  });
//}