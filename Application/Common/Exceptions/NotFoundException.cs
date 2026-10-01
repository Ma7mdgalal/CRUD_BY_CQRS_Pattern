using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Common.Exceptions;

public class NotFoundException(string Entity, Guid id) : Exception($"The Entity: {Entity} with Id: {id} not Found");
