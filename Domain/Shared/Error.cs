using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public sealed record Error(string ErrorCode, string? ErrorMessage = null)
    {
        public static readonly Error None = new Error(string.Empty);
        public static Error NotFound(string message) => new Error("Not found", message);
        public static Error InvalidData(string message) => new Error("Invalid data", message);
        public static Error BadRequest(string message) => new Error("Bad request", message);
        public static Error OperationFailed(string message) => new Error("Operation failed", message);
        public static Error Conflict(string message) => new Error("Conflict", message);
    }
}
