﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace PlaDiC.Data
{
	/// <summary>
	/// Lets you efficiently bulk load a SQL Server table with data from another source.
	/// This is a wrapper class for <see cref="SqlBulkCopy"/>
	/// </summary>
	public class BulkCopy
	{
		/// <summary>
		/// Name of the destination table on the server
		/// </summary>
		public string DestinationTableName
		{
			get;
			set;
		}


		/// <summary>
		/// Number of rows in each batch. 
		/// At the end of each batch, the rows in the batch are sent to the server.
		/// </summary>
		public int? BatchSize
		{
			get;
			set;
		}


		/// <summary>
		/// Database connection string
		/// </summary>
		public string ConnectionString
		{
			get;
			set;
		}


		/// <summary>
		/// Filters the properties to be included
		/// </summary>
		public Func<PropertyDescriptor, bool> ExpressionFilter
		{
			get;
			set;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="BulkCopy&lt;T&gt;"/> class.
		/// </summary>
		public BulkCopy()
		{
			
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="BulkCopy&lt;T&gt;"/> class.
		/// </summary>
		public BulkCopy(string connectionString)
		{

			this.ConnectionString = connectionString;
		}


		/// <summary>
		/// Copies all items in a collection to a destination table
		/// </summary>
		/// <param name="dataTable">The items that will be copied to the destination table</param>
		/// <param name="options">A combination of values from the System.Data.SqlClient.SqlBulkCopyOptions 
		/// enumeration that determines which data source rows are copied to the destination table. <see cref="SqlBulkCopyOptions"/></param>
		public virtual void WriteToServer<T>(IEnumerable<T> items) where T : class
		{
            WriteToServer(items, SqlBulkCopyOptions.Default);
		}


		/// <summary>
		/// Copies all items in a collection to a destination table
		/// </summary>
		/// <param name="dataTable">The items that will be copied to the destination table</param>
		/// <param name="options">A combination of values from the System.Data.SqlClient.SqlBulkCopyOptions 
		/// enumeration that determines which data source rows are copied to the destination table. <see cref="SqlBulkCopyOptions"/></param>
		public virtual void WriteToServer<T>(IEnumerable<T> items, SqlBulkCopyOptions options) where T : class
		{
			DataTable dataTable = (this.ExpressionFilter == null) ? items.ToDataTable() : items.ToDataTable(this.ExpressionFilter);

			WriteToServer(dataTable, options);
		}


		/// <summary>
		/// Copies all items in a collection to a destination table
		/// </summary>
		/// <param name="dataTable">The items that will be copied to the destination table</param>
		/// <param name="options">A combination of values from the System.Data.SqlClient.SqlBulkCopyOptions 
		/// enumeration that determines which data source rows are copied to the destination table. <see cref="SqlBulkCopyOptions"/></param>
		/// <param name="columnMappings">Returns a collection of System.Data.SqlClient.SqlBulkCopyColumnMapping items. 
		/// Column mappings define the relationships between columns in the data source and columns in the destination.</param>
		public virtual void WriteToServer<T>(IEnumerable<T> items, SqlBulkCopyOptions options, IEnumerable<SqlBulkCopyColumnMapping> columnMappings) where T : class
		{
			DataTable dataTable = (this.ExpressionFilter == null) ? items.ToDataTable() : items.ToDataTable(this.ExpressionFilter);

			WriteToServer(dataTable, options, columnMappings);
		}


		/// <summary>
		/// Copies all rows in the supplied System.Data.DataTable to a destination table
		/// </summary>
		/// <param name="dataTable">A System.Data.DataTable whose rows will be copied to the destination table</param>
		private void WriteToServer(DataTable dataTable)
		{
			WriteToServer(dataTable, SqlBulkCopyOptions.Default);
		}


		/// <summary>
		/// Copies all rows in the supplied System.Data.DataTable to a destination table
		/// </summary>
		/// <param name="dataTable">A System.Data.DataTable whose rows will be copied to the destination table</param>
		/// <param name="options">A combination of values from the System.Data.SqlClient.SqlBulkCopyOptions 
		/// enumeration that determines which data source rows are copied to the destination table. <see cref="SqlBulkCopyOptions"/></param>
		private void WriteToServer(DataTable dataTable, SqlBulkCopyOptions options)
		{
			var columnMappings = from x in dataTable.Columns.Cast<DataColumn>()
								 select new SqlBulkCopyColumnMapping(x.ColumnName, x.ColumnName);

			WriteToServer(dataTable, options, columnMappings);
		}


		/// <summary>
		/// Copies all rows in the supplied System.Data.DataTable to a destination table
		/// </summary>
		/// <param name="dataTable">A System.Data.DataTable whose rows will be copied to the destination table</param>
		/// <param name="options">A combination of values from the System.Data.SqlClient.SqlBulkCopyOptions 
		/// enumeration that determines which data source rows are copied to the destination table. <see cref="SqlBulkCopyOptions"/></param>
		/// <param name="columnMappings">Returns a collection of System.Data.SqlClient.SqlBulkCopyColumnMapping items. 
		/// Column mappings define the relationships between columns in the data source and columns in the destination.</param>
		private void WriteToServer(DataTable dataTable, SqlBulkCopyOptions options, IEnumerable<SqlBulkCopyColumnMapping> columnMappings)
		{
			// table name matching:
			// checks for DestinationTableName value
			// if null or empty, checks for dataTable.TableName
			string destinationTableName =
				(string.IsNullOrWhiteSpace(DestinationTableName) ? null : DestinationTableName)
				?? (string.IsNullOrWhiteSpace(dataTable.TableName) ? null : dataTable.TableName);

			if(string.IsNullOrWhiteSpace(destinationTableName))
				throw new ArgumentException("destinationTableName cannot be null or empty");

			using(var bulkCopy = new SqlBulkCopy(this.ConnectionString, options))
			{
				bulkCopy.DestinationTableName = destinationTableName;

				if(this.BatchSize.HasValue)
					bulkCopy.BatchSize = this.BatchSize.Value;

				foreach(var mapping in columnMappings)
					bulkCopy.ColumnMappings.Add(mapping);

				bulkCopy.WriteToServer(dataTable);
			}
		}
	}
}


