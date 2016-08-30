using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;

namespace SequenceStudio.Validate
{
    /// <summary>
    /// This attribute validates that the input string is a valid DNA sequence.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateDnaAttribute : ValidateArgumentsAttribute
    {
        public ValidateDnaAttribute() { }
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (!ValidateMethods.IsValidDna(arguments.ToString()))
            {
                InvocationInfo myCmdlet = (InvocationInfo)engineIntrinsics.SessionState.PSVariable.Get("MyInvocation").Value;
                CommandInfo cmdInfo = myCmdlet.MyCommand;

                String message = "ValidateDNA: Invalid parameter value. The value must be a valid DNA strand with only the characters [ACGT].";
                String recommendedAction = "Try the command again using the correct input value.";
                String reason = "The value must be a valid DNA strand with only the characters [ACGT].";
                String activity = "Parameter Validation";
                String target = cmdInfo.ToString().Replace("\"", " '");
                String targetType = "String";


                ValidationError.ThrowTerminatingError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }


    /// <summary>
    /// This attribute validates that the input string is a valid RNA sequence.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateRnaAttribute : ValidateArgumentsAttribute
    {
        public ValidateRnaAttribute() { }
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (!ValidateMethods.IsValidRna(arguments.ToString()))
            {
                InvocationInfo myCmdlet = (InvocationInfo)engineIntrinsics.SessionState.PSVariable.Get("MyInvocation").Value;
                CommandInfo cmdInfo = myCmdlet.MyCommand;

                String message = "ValidateGuid : Invalid parameter value. The value must be a valid DNA strand with only the characters [ACGT].";
                String recommendedAction = "You can get this by using $var = [guid]::NewGuid or by entering the string representation of a valid GUID. Try the command again using the correct input value.";
                String reason = "Invalid parameter value. The value must be a valid GUID.";
                String activity = "Parameter Validation";
                String target = cmdInfo.ToString().Replace("\"", " '");
                String targetType = "String";


                ValidationError.ThrowTerminatingError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }


    /// <summary>
    /// This attribute validates that the input string is a valid polypeptide sequence.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidatePolyAttribute : ValidateArgumentsAttribute
    {
        public ValidatePolyAttribute() { }
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (!ValidateMethods.IsValidPolypeptide(arguments.ToString()))
            {
                InvocationInfo myCmdlet = (InvocationInfo)engineIntrinsics.SessionState.PSVariable.Get("MyInvocation").Value;
                CommandInfo cmdInfo = myCmdlet.MyCommand;

                String message = "ValidateGuid : Invalid parameter value. The value must be a valid DNA strand with only the characters [ACGT].";
                String recommendedAction = "You can get this by using $var = [guid]::NewGuid or by entering the string representation of a valid GUID. Try the command again using the correct input value.";
                String reason = "Invalid parameter value. The value must be a valid GUID.";
                String activity = "Parameter Validation";
                String target = cmdInfo.ToString().Replace("\"", " '");
                String targetType = "String";


                ValidationError.ThrowTerminatingError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }


    /// <summary>
    /// This attribute validates that the input string is a valid Strand Type. 
    /// the Valid values are 'RNA' | 'DNA' | 'POLYPEPTIDE'
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateStrandTypeAttribute : ValidateArgumentsAttribute
    {
        public ValidateStrandTypeAttribute() { }
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (!ValidateMethods.IsValidStrandType(arguments.ToString()))
            {
                InvocationInfo myCmdlet = (InvocationInfo)engineIntrinsics.SessionState.PSVariable.Get("MyInvocation").Value;
                CommandInfo cmdInfo = myCmdlet.MyCommand;

                String message = "ValidateGuid : Invalid parameter value. The value must be a valid DNA strand with only the characters [ACGT].";
                String recommendedAction = "You can get this by using $var = [guid]::NewGuid or by entering the string representation of a valid GUID. Try the command again using the correct input value.";
                String reason = "Invalid parameter value. The value must be a valid GUID.";
                String activity = "Parameter Validation";
                String target = cmdInfo.ToString().Replace("\"", " '");
                String targetType = "String";


                ValidationError.ThrowTerminatingError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }


    /// <summary>
    /// This attribute validates that the input object is either a DNA, RNA, or Poly class instance. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateSequenceObjectAttribute : ValidateArgumentsAttribute
    {
        public ValidateSequenceObjectAttribute() { }
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if ((!ValidateMethods.IsValidSequenceObject(arguments.ToString())) || (!ValidateMethods.IsValidSequence(arguments.ToString())))
            {
                InvocationInfo myCmdlet = (InvocationInfo)engineIntrinsics.SessionState.PSVariable.Get("MyInvocation").Value;
                CommandInfo cmdInfo = myCmdlet.MyCommand;

                String message = "ValidateGuid : Invalid parameter value. The value must be a valid DNA, RNA, or Poly class instance.";
                String recommendedAction = "You can get this by using New-DNA, New-RNA, or New-Poly, Try the command again using the correct input value.";
                String reason = "Invalid parameter value. The value must be a valid DNA, RNA, or Poly class instance.";
                String activity = "Parameter Validation";
                String target = cmdInfo.ToString().Replace("\"", " '");
                String targetType = "String";


                ValidationError.ThrowTerminatingError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }



    /// <summary>
    /// This attribute validates that the input strand is a valid strand, either 
    /// a DNA, an RNA, or a Polypettide. This is used for methods that take any one of these strand types.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateSequenceAttribute : ValidateArgumentsAttribute
    {
        public ValidateSequenceAttribute() { }
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (!ValidateMethods.IsValidSequence(arguments.ToString()))
            {
                InvocationInfo myCmdlet = (InvocationInfo)engineIntrinsics.SessionState.PSVariable.Get("MyInvocation").Value;
                CommandInfo cmdInfo = myCmdlet.MyCommand;

                String message = "ValidateGuid : Invalid parameter value. The value must be a valid DNA strand with only the characters [ACGT].";
                String recommendedAction = "You can get this by using $var = [guid]::NewGuid or by entering the string representation of a valid GUID. Try the command again using the correct input value.";
                String reason = "Invalid parameter value. The value must be a valid GUID.";
                String activity = "Parameter Validation";
                String target = cmdInfo.ToString().Replace("\"", " '");
                String targetType = "String";


                ValidationError.ThrowTerminatingError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }


    /// <summary>
    /// This attribute validates that the input double is between 0 and 100.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateThresholdAttribute : ValidateArgumentsAttribute
    {
        public ValidateThresholdAttribute() { }
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (!ValidateMethods.IsValidThreshould(Convert.ToDouble(arguments)))
            {
                InvocationInfo myCmdlet = (InvocationInfo)engineIntrinsics.SessionState.PSVariable.Get("MyInvocation").Value;
                CommandInfo cmdInfo = myCmdlet.MyCommand;

                String message = "ValidateGuid : Invalid parameter value. The value must be a valid GUID.";
                String recommendedAction = "You can get this by using $var = [guid]::NewGuid or by entering the string representation of a valid GUID. Try the command again using the correct input value.";
                String reason = "Invalid parameter value. The value must be a valid GUID.";
                String activity = "Parameter Validation";
                String target = cmdInfo.ToString().Replace("\"", " '");
                String targetType = "String";


                ValidationError.ThrowTerminatingError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }

}
