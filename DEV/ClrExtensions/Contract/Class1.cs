using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace System.Diagnostics.Contracts
{
    // Summary:
    //     Contains static methods for representing program contracts such as preconditions,
    //     postconditions, and invariants.
    public static class Contract
    {
        // Summary:
        //     Occurs when a contract fails.
        //public static event EventHandler<ContractFailedEventArgs> ContractFailed;

        // Summary:
        //     Checks for a condition; if the condition is false, follows the escalation
        //     policy set for the analyzer.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to test.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [Conditional("CONTRACTS_FULL")]
        [Conditional("DEBUG")]
        public static void Assert(bool condition) { }
        //
        // Summary:
        //     Checks for a condition{} if the condition is false, follows the escalation
        //     policy set by the analyzer and displays a specified message.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to test.
        //
        //   userMessage:
        [Conditional("DEBUG")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [Conditional("CONTRACTS_FULL")]
        public static void Assert(bool condition, string userMessage) { }
        //
        // Summary:
        //     Instructs code analysis tools to assume that the specified condition is true,
        //     even if it cannot be statically proven to always be true.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to assume true.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [Conditional("DEBUG")]
        [Conditional("CONTRACTS_FULL")]
        public static void Assume(bool condition) { }
        //
        // Summary:
        //     Instructs code analysis tools to assume that a condition is true, even if
        //     it cannot be statically proven to always be true, and displays a message
        //     if the assumption fails.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to assume true.
        //
        //   userMessage:
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [Conditional("CONTRACTS_FULL")]
        [Conditional("DEBUG")]
        public static void Assume(bool condition, string userMessage) { }
        //
        // Summary:
        //     Identifies the end of a contract block.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [Conditional("CONTRACTS_FULL")]
        public static void EndContractBlock() { }
        //
        // Summary:
        //     Specifies a postcondition contract for a specified exit condition.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to test. The expression may include System.Diagnostics.Contracts.Contract.OldValue<T0>(T0),
        //     System.Diagnostics.Contracts.Contract.ValueAtReturn<T0>(T0@), and System.Diagnostics.Contracts.Contract.Result<T0>()
        //     values.
        [Conditional("CONTRACTS_FULL")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static void Ensures(bool condition) { }
        //
        // Summary:
        //     Specifies a postconditon contract for a specified exit condition and a message
        //     to display if the condition is false.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to test. The expression may include System.Diagnostics.Contracts.Contract.OldValue<T0>(T0)
        //     and System.Diagnostics.Contracts.Contract.Result<T0>() values.
        //
        //   userMessage:
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [Conditional("CONTRACTS_FULL")]
        public static void Ensures(bool condition, string userMessage) { }
        //
        // Summary:
        //     Specifies a postcondition contract for the specified exception and condition.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to test.
        //
        // Type parameters:
        //   TException:
        //     The type of exception that invokes the postcondition check.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [Conditional("CONTRACTS_FULL")]
        public static void EnsuresOnThrow<TException>(bool condition) where TException : Exception { }
        //
        // Summary:
        //     Specifies a postcondition contract for the specified exception and condition
        //     and a message to display if the condition is false.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to test.
        //
        //   userMessage:
        //
        // Type parameters:
        //   TException:
        //     The type of exception that invokes the postcondition check.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [Conditional("CONTRACTS_FULL")]
        public static void EnsuresOnThrow<TException>(bool condition, string userMessage) where TException : Exception { }
        //
        // Summary:
        //     Determines whether all the elements in a collection exist within a function.
        //
        // Parameters:
        //   collection:
        //     The collection from which elements of type T will be drawn to pass to predicate.
        //
        //   predicate:
        //     The function to evaluate for the existence of an element in collection.
        //
        // Type parameters:
        //   T:
        //     The type that is contained in collection.
        //
        // Returns:
        //     true if and only if predicate returns true for all elements of type T in
        //     collection.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     collection or predicate is null.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static bool Exists<T>(IEnumerable<T> collection, Predicate<T> predicate) { return false; }
        //
        // Summary:
        //     Determines whether a range of integers exists within a function.
        //
        // Parameters:
        //   fromInclusive:
        //
        //   toExclusive:
        //
        //   predicate:
        //     The function to evaluate for the existence of an integer in the specified
        //     range.
        //
        // Returns:
        //     true if predicate returns true for any integer starting from inclusiveLowerBound
        //     to exclusiveUpperBound - 1.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     predicate is null.
        //
        //   System.ArgumentException:
        //     exclusiveUpperBound is less than inclusiveLowerBound.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static bool Exists(int fromInclusive, int toExclusive, Predicate<int> predicate) { return false; }
        //
        // Summary:
        //     Determines whether all the elements in a collection exist within a function.
        //
        // Parameters:
        //   collection:
        //     The collection from which elements of type T will be drawn to pass to predicate.
        //
        //   predicate:
        //     The function to evaluate for the existence of all the elements in collection.
        //
        // Type parameters:
        //   T:
        //     The type that is contained in collection.
        //
        // Returns:
        //     true if and only if predicate returns true for all elements of type T in
        //     collection.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     collection or predicate is null.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static bool ForAll<T>(IEnumerable<T> collection, Predicate<T> predicate) { return false; }
        //
        // Summary:
        //     Determines whether all integers within a specified range exist within a function.
        //
        // Parameters:
        //   fromInclusive:
        //
        //   toExclusive:
        //
        //   predicate:
        //     The function to evaluate for the existence of the integers in the specified
        //     range.
        //
        // Returns:
        //     true if predicate returns true for all integers starting from inclusiveLowerBound
        //     to exclusiveUpperBound - 1.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     predicate is null.
        //
        //   System.ArgumentException:
        //     exclusiveUpperBound is less than inclusiveLowerBound.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static bool ForAll(int fromInclusive, int toExclusive, Predicate<int> predicate) { return false; }
        //
        // Summary:
        //     Specifies a contract such that the condition will be true after every method
        //     or property on the enclosing class ends.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to test.
        [Conditional("CONTRACTS_FULL")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static void Invariant(bool condition) { }
        //
        // Summary:
        //     Specifies a contract such that the condition will be true after every method
        //     or property on the enclosing class ends, and displays a message if the condition
        //     fails.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to test.
        //
        //   userMessage:
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [Conditional("CONTRACTS_FULL")]
        public static void Invariant(bool condition, string userMessage) { }
        //
        // Summary:
        //     Represents the value of a field or parameter at the start of a method or
        //     property.
        //
        // Parameters:
        //   value:
        //     The value to represent (field or parameter).
        //
        // Type parameters:
        //   T:
        //     The type of value.
        //
        // Returns:
        //     The value of the parameter or field at the start of a method or property.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static T OldValue<T>(T value) { return default(T); }
        //
        //
        // Type parameters:
        //   TException:
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static void Requires<TException>(bool condition) where TException : Exception { }
        //
        // Summary:
        //     Specifies a precondition contract such that a condition must be true before
        //     the enclosing method or property is invoked.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to test.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [Conditional("CONTRACTS_FULL")]
        public static void Requires(bool condition) { }
        //
        // Summary:
        //     Specifies a precondition contract such that a condition must be true before
        //     the enclosing method or property is invoked, and displays a message if the
        //     condition fails.
        //
        // Parameters:
        //   condition:
        //     The conditional expression to test.
        //
        //   userMessage:
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [Conditional("CONTRACTS_FULL")]
        public static void Requires(bool condition, string userMessage) { }
        //
        //
        // Type parameters:
        //   TException:
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static void Requires<TException>(bool condition, string userMessage) where TException : Exception { }
        //
        // Summary:
        //     Represents the return value of a method or property.
        //
        // Type parameters:
        //   T:
        //     Type of return value of the enclosing method or property.
        //
        // Returns:
        //     Return value of the enclosing method or property.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static T Result<T>() { return default(T); }
        //
        // Summary:
        //     Represents the final (output) value of an out parameter when returning from
        //     a method.
        //
        // Parameters:
        //   value:
        //     The out parameter.
        //
        // Type parameters:
        //   T:
        //     The type of the out parameter.
        //
        // Returns:
        //     The output value of the out parameter.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static T ValueAtReturn<T>(out T value) { value = default(T); return default(T); }
    }
}



namespace System.Diagnostics.Contracts
{
    // Summary:
    //     Provides methods and data for the System.Diagnostics.Contracts.Contract.ContractFailed
    //     event.
    public sealed class ContractFailedEventArgs : EventArgs
    {
        // Summary:
        //     Provides data for the System.Diagnostics.Contracts.Contract.ContractFailed
        //     event.
        //
        // Parameters:
        //   failureKind:
        //     One of the enumeration values that specifies the contract that failed.
        //
        //   message:
        //     The message for the event.
        //
        //   condition:
        //     The condition for the event.
        //
        //   originalException:
        //     The exception that caused the event.
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public ContractFailedEventArgs(ContractFailureKind failureKind, string message, string condition, Exception originalException) { }

        // Summary:
        //     Gets the condition for the failure.
        //
        // Returns:
        //     The condition for the failure.
        public string Condition { get { return null; } }
        //
        // Summary:
        //     Gets the type of contract that failed.
        //
        // Returns:
        //     One of the enumeration values that specifies the type of contract that failed.
        public ContractFailureKind FailureKind { get { return 0; } }
        //
        // Summary:
        //     Indicates whether the event has been handled.
        //
        // Returns:
        //     true if the event has been handled; otherwise, false.
        public bool Handled {  get { return false; } }
        //
        // Summary:
        //     Gets the message for the event.
        //
        // Returns:
        //     The message that describes the event.
        public string Message {  get { return null; } }
        //
        // Summary:
        //     Gets the original exception that caused the event.
        //
        // Returns:
        //     The original exception.
        public Exception OriginalException {  get { return null; } }
        //
        // Summary:
        //     Indicates whether the code contract escalation policy should be applied.
        //
        // Returns:
        //     true to apply the escalation policy; otherwise, false. The default is true.
        public bool Unwind {  get { return false; } }

        // Summary:
        //     Sets the System.Diagnostics.Contracts.ContractFailedEventArgs.Handled property
        //     to true.
        public void SetHandled(){}
        //
        // Summary:
        //     Sets the System.Diagnostics.Contracts.ContractFailedEventArgs.Unwind property
        //     to true.
        public void SetUnwind(){}
    }
}


namespace System.Diagnostics.Contracts
{
    // Summary:
    //     Specifies the type of contract that failed.
    public enum ContractFailureKind
    {
        // Summary:
        //     A Overload:System.Diagnostics.Contracts.Contract.Requires contract failed.
        Precondition = 0,
        //
        // Summary:
        //     An Overload:System.Diagnostics.Contracts.Contract.Ensures contract failed.
        Postcondition = 1,
        //
        // Summary:
        //     An Overload:System.Diagnostics.Contracts.Contract.EnsuresOnThrow contract
        //     failed.
        PostconditionOnException = 2,
        //
        // Summary:
        //     An Overload:System.Diagnostics.Contracts.Contract.Invariant contract failed.
        Invariant = 3,
        //
        // Summary:
        //     An Overload:System.Diagnostics.Contracts.Contract.Assert contract failed.
        Assert = 4,
        //
        // Summary:
        //     An Overload:System.Diagnostics.Contracts.Contract.Assume contract failed.
        Assume = 5,
    }

    public class ContractInvariantMethodAttribute:Attribute {
    }
}
