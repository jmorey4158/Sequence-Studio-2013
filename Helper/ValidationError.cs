using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;

namespace SequenceStudio.Validate
{
        public static class ValidationError
        {
            public static void ThrowError(String message, String recommendedAction, String reason, String activity, String target, String targetType)
            {
                ValidationMetadataException ve = new ValidationMetadataException(message);

                ErrorRecord er = new ErrorRecord(
                    ve,
                    message,
                    ErrorCategory.InvalidData,
                     ve.Source);

                er.CategoryInfo.Activity = activity;
                er.CategoryInfo.Reason = reason;
                er.CategoryInfo.TargetName = target;
                er.CategoryInfo.TargetType = targetType;

                ErrorDetails ed = new ErrorDetails(message);
                ed.RecommendedAction = recommendedAction;
                er.ErrorDetails = ed;

            
            }

            public static void ThrowTerminatingError(String message, String recommendedAction, String reason, String activity, String target, String targetType)
            {
                ValidationMetadataException ve = new ValidationMetadataException(message);

                ErrorRecord er = new ErrorRecord(
                    ve,
                    message,
                    ErrorCategory.InvalidData,
                     ve.Source);

                er.CategoryInfo.Activity = activity;
                er.CategoryInfo.Reason = reason;
                er.CategoryInfo.TargetName = target;
                er.CategoryInfo.TargetType = targetType;

                ErrorDetails ed = new ErrorDetails(message);
                ed.RecommendedAction = recommendedAction;
                er.ErrorDetails = ed;

                new NewValidationErrorCmdlt().ThrowTerminatingError(er);
            }
        }



        [Cmdlet(VerbsCommon.New, "ValidationError")]
        public class NewValidationErrorCmdlt : Cmdlet
        {
            protected override void ProcessRecord() { ;}
        }

}
