﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkFlowServices
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class wfe_sampleEntities : DbContext
    {
        public wfe_sampleEntities()
            : base("name=wfe_sampleEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<WorkflowGlobalParameter> WorkflowGlobalParameters { get; set; }
        public DbSet<WorkflowInbox> WorkflowInboxes { get; set; }
        public DbSet<WorkflowProcessInstance> WorkflowProcessInstances { get; set; }
        public DbSet<WorkflowProcessInstancePersistence> WorkflowProcessInstancePersistences { get; set; }
        public DbSet<WorkflowProcessInstanceStatu> WorkflowProcessInstanceStatus { get; set; }
        public DbSet<WorkflowProcessScheme> WorkflowProcessSchemes { get; set; }
        public DbSet<WorkflowProcessTimer> WorkflowProcessTimers { get; set; }
        public DbSet<WorkflowProcessTransitionHistory> WorkflowProcessTransitionHistories { get; set; }
        public DbSet<WorkflowScheme> WorkflowSchemes { get; set; }
        public DbSet<WorkflowServerProcessHistory> WorkflowServerProcessHistories { get; set; }
        public DbSet<WorkflowServerStat> WorkflowServerStats { get; set; }
    }
}
