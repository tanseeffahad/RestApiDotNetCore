using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Repositories;
using Repositories.Interfaces;
using DatabaseManagement.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class TaskService : ITaskService
    {
        //private readonly IProductRepository _productRepository;
        //private readonly ICategoryRepository _categoryRepository;
        //private readonly IMapper _mapper;
        //public TaskService(IProductRepository productRepository, ICategoryRepository categoryRepository, ISub_CategoryRepository sub_CategoryRepository, IProductImagesRepository productImagesRepository, IMapper mapper)
        //{
        //    this._productRepository = productRepository;
        //    this._categoryRepository = categoryRepository;
        //    this._sub_CategoryRepository = sub_CategoryRepository;
        //    this._productImagesRepository = productImagesRepository;


        //    _mapper = mapper;
        //}

        //public async Task<List<CategoryResource>> GetAllCategories()
        //{
        //    var categories = await this._categoryRepository.GetAllCategories();
        //    return _mapper.Map<List<Category>, List<CategoryResource>>(categories);
        //}
        //public async Task<string> AddUpdateCategory(ProductModel model)
        //{
        //    try
        //    {
        //        if (model.CategoryResource.CategoryId == 0)
        //        {
        //            var emailExistsAlready = await this._categoryRepository.GetByCategoryNameAsync(model.CategoryResource.CategoryName);
        //            if (emailExistsAlready != null)
        //            {
        //                return "Category Name Already Exists";
        //            }
        //            var category = new Category
        //            {
        //                CategoryName = model.CategoryResource.CategoryName,
        //                Description = model.CategoryResource.Description,
        //                CreatedBy = "Admin",
        //                CreatedTime = DateTime.Now,
        //            };
        //            await this._categoryRepository.AddAsync(category);
        //            return "success";
        //        }
        //        else
        //        {
        //            var item = await this._categoryRepository.GetById(model.CategoryResource.CategoryId);
        //            //item.CategoryName = model.CategoryResource.Description;
        //            item.Description = model.CategoryResource.Description;

        //            await this._categoryRepository.UpdateAsync(item);
        //            return "success";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "fail";
        //    }
        //}

        //public async Task<CategoryResource> GetById(int CategoryId)
        //{
        //    var category = await this._categoryRepository.GetById(CategoryId);
        //    return _mapper.Map<Category, CategoryResource>(category);
        //}

        //public async Task<string> DeletebyID(int Id)
        //{
        //    var category = await this._categoryRepository.GetById(Id);
        //    await this._categoryRepository.Deletesync(category);
        //    return "success";
        //}

    }
}
