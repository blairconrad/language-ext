﻿using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using static LanguageExt.Prelude;

namespace LanguageExt
{
    /// <summary>
    /// 
    ///     Process registration - a kind of DNS for Processes
    /// 
    ///     If the Process is visible to the cluster (PersistInbox) then the 
    ///     registration becomes a permanent named look-up until Process.deregister 
    ///     is called.
    ///     
    ///     Multiple Processes can register under the same name.  You may use 
    ///     a dispatcher to work on them collectively (wherever they are in the 
    ///     cluster).  i.e. 
    /// 
    ///         var regd = register("regd-name", pid);
    ///         
    ///         tell(Dispatch.Broadcast[regd],  "Hello");
    ///         tell(Dispatch.First[regd],      "Hello");
    ///         tell(Dispatch.LeastBusy[regd],  "Hello");
    ///         tell(Dispatch.Random[regd],     "Hello");
    ///         tell(Dispatch.RoundRobin[regd], "Hello");
    /// 
    /// </summary>
    public static partial class Process
    {
        /// <summary>
        /// Find a process by its *registered* name (a kind of DNS for Processes).
        /// 
        /// See remarks.
        /// </summary>
        /// <remarks>
        /// Multiple Processes can register under the same name.  You may use 
        /// a dispatcher to work on them collectively (wherever they are in the 
        /// cluster).  i.e. 
        /// 
        ///     var regd = register("proc", pid);
        ///     tell(Dispatch.Broadcast[regd], "Hello");
        ///     tell(Dispatch.First[regd], "Hello");
        ///     tell(Dispatch.LeastBusy[regd], "Hello");
        ///     tell(Dispatch.Random[regd], "Hello");
        ///     tell(Dispatch.RoundRobin[regd], "Hello");
        /// 
        /// </remarks>
        /// <param name="name">Process name</param>
        /// <returns>A ProcessId that allows dispatching to the process(es).  The result
        /// would look like /disp/reg/name</returns>
        public static ProcessId find(ProcessName name) =>
            ActorContext.Disp["reg"][name];

        /// <summary>
        /// Register a named process (a kind of DNS for Processes).  
        /// 
        /// If the Process is visible to the cluster (PersistInbox) then the 
        /// registration becomes a permanent named look-up until Process.deregister 
        /// is called.
        /// 
        /// See remarks.
        /// </summary>
        /// <remarks>
        /// Multiple Processes can register under the same name.  You may use 
        /// a dispatcher to work on them collectively (wherever they are in the 
        /// cluster).  i.e. 
        /// 
        ///     var regd = register("proc");
        ///     tell(Dispatch.Broadcast[regd], "Hello");
        ///     tell(Dispatch.First[regd], "Hello");
        ///     tell(Dispatch.LeastBusy[regd], "Hello");
        ///     tell(Dispatch.Random[regd], "Hello");
        ///     tell(Dispatch.RoundRobin[regd], "Hello");
        /// 
        ///     This should be used from within a process' message loop only
        /// </remarks>
        /// <param name="name">Name to register under</param>
        /// <returns>A ProcessId that allows dispatching to the process via the name.  The result
        /// would look like /disp/reg/name</returns>
        public static ProcessId register(ProcessName name) =>
            InMessageLoop
                ? ActorContext.Register(name, Self)
                : raiseUseInMsgLoopOnlyException<ProcessId>(nameof(name));

        /// <summary>
        /// Register a named process (a kind of DNS for Processes).  
        /// 
        /// If the Process is visible to the cluster (PersistInbox) then the 
        /// registration becomes a permanent named look-up until Process.deregister 
        /// is called.
        /// 
        /// See remarks.
        /// </summary>
        /// <remarks>
        /// Multiple Processes can register under the same name.  You may use 
        /// a dispatcher to work on them collectively (wherever they are in the 
        /// cluster).  i.e. 
        /// 
        ///     var regd = register("proc", pid);
        ///     tell(Dispatch.Broadcast[regd], "Hello");
        ///     tell(Dispatch.First[regd], "Hello");
        ///     tell(Dispatch.LeastBusy[regd], "Hello");
        ///     tell(Dispatch.Random[regd], "Hello");
        ///     tell(Dispatch.RoundRobin[regd], "Hello");
        /// 
        /// </remarks>
        /// <param name="name">Name to register under</param>
        /// <param name="process">Process to be registered</param>
        /// <returns>A ProcessId that allows dispatching to the process(es).  The result
        /// would look like /disp/reg/name</returns>
        public static ProcessId register(ProcessName name, ProcessId process) =>
            ActorContext.Register(name, process);

        /// <summary>
        /// Deregister a Process from any names it's been registered as.
        /// 
        /// See remarks.
        /// </summary>
        /// <remarks>
        /// Any Process (or dispatcher, or role, etc.) can be registered by a name - 
        /// a kind of DNS for ProcessIds.  There can be multiple names associated
        /// with a single ProcessId.  
        /// 
        /// This function removes all registered names for a specific ProcessId.
        /// If you wish to deregister all ProcessIds registered under a name then
        /// use Process.deregisterByName(name)
        /// </remarks>
        /// <param name="name">Name of the process to deregister</param>
        public static Unit deregisterById(ProcessId process) =>
            ActorContext.DeregisterById(process);

        /// <summary>
        /// Deregister all Processes associated with a name. NOTE: Be very careful
        /// with usage of this function if you didn't handle the registration you
        /// are potentially disconnecting many Processes from their registered name.
        /// 
        /// See remarks.
        /// </summary>
        /// <remarks>
        /// Any Process (or dispatcher, or role, etc.) can be registered by a name - 
        /// a kind of DNS for ProcessIds.  There can be multiple names associated
        /// with a single ProcessId and multiple ProcessIds associated with a name.
        /// 
        /// This function removes all registered ProcessIds for a specific name.
        /// If you wish to deregister all names registered for specific Process then
        /// use Process.deregisterById(name)
        /// </remarks>
        /// <param name="name">Name of the process to deregister</param>
        public static Unit deregisterByName(ProcessId process) =>
            ActorContext.DeregisterById(process);
    }
}
