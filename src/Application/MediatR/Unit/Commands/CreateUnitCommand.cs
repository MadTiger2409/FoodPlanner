﻿using FoodPlanner.Application.Mappings.Dtos.Unit;
using MediatR;

namespace FoodPlanner.Application.MediatR.Unit.Commands
{
    public record CreateUnitCommand(string Name) : IRequest<UnitDto>;
}