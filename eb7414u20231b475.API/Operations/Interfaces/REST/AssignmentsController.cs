using System.Net.Mime;
using eb7414u20231b475.API.Operations.Domain.Services;
using eb7414u20231b475.API.Operations.Interfaces.REST.Resources;
using eb7414u20231b475.API.Operations.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace eb7414u20231b475.API.Operations.Interfaces.REST
{
    /// <summary>
    /// The Assignments controller
    /// </summary>
    [ApiController]
    [Route("api/v1/buses/{busId}/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Available Assignment endpoints")]
    public class AssignmentsController(IAssignmentCommandService service) : ControllerBase
    {
        /// <summary>
        /// Create a new assignment
        /// </summary>
        /// <param name="busId">The bus id</param>
        /// <param name="resource">The <see cref="CreateAssignmentResource"/></param>
        /// <returns>The <see cref="AssignmentResource" /> created, or a bad request if the assignment could not be created</returns>
        [HttpPost]
        [SwaggerOperation("Create an assignment", "Create a new assignment", OperationId = "CreateAssignment")]
        [SwaggerResponse(201, "The assignment was created!", typeof(AssignmentResource))]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<IActionResult> CreateAssignment([FromRoute] int busId, [FromBody] CreateAssignmentResource resource)
        {
            var createAssignmentCommand = CreateAssignmentCommandFromResourceAssembler.ToCommandFromResource(busId, resource);
            var assignment = await service.Handle(createAssignmentCommand);
            if (assignment is null) return BadRequest();
            var assignmentResource = AssignmentResourceFromEntityAssembler.ToResourceFromEntity(assignment);
            return StatusCode(StatusCodes.Status201Created, assignmentResource);
        }
    }
}