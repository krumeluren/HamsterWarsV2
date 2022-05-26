﻿using Shared.DataTransferObject;

namespace Service.Contracts;
public interface ICompanyService
{
    IEnumerable<CompanyDto> GetAll(bool trackChanges);
}
