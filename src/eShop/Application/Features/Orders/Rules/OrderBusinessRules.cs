using Application.Features.Orders.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Rules;

public class OrderBusinessRules : BaseBusinessRules
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILocalizationService _localizationService;

    public OrderBusinessRules(IOrderRepository orderRepository, ILocalizationService localizationService)
    {
        _orderRepository = orderRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, OrdersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task OrderShouldExistWhenSelected(Order? order)
    {
        if (order == null)
            await throwBusinessException(OrdersBusinessMessages.OrderNotExists);
    }

    public async Task OrderIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.GetAsync(
            predicate: o => o.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrderShouldExistWhenSelected(order);
    }

    public async Task<string> GetNewOrderNumber()
    {
        const string initialLetter = "SO"; 
        string year = DateTime.Now.Year.ToString();
        string newOrderNumber = initialLetter + year;

        Order? lastOrder = await _orderRepository.Query().OrderByDescending(o => o.Id).FirstOrDefaultAsync();
        string? currentOrderNumber = lastOrder?.OrderNumber; // son siparişin numarası
        if (currentOrderNumber != null)
        {
            string currentYear = currentOrderNumber.Substring(2, 4);
            int startIndex = (currentYear == year) ? 6 : 0;
            await generateUniqueOrderNumber( newOrderNumber, currentOrderNumber[startIndex..]);
        }
        else
        {
            newOrderNumber += "0000000001";
        }
        return newOrderNumber;
    }

    private async Task generateUniqueOrderNumber(string newOrderNumber, string currentOrderNumStr)
    {
        int currentOrderNumberInt = int.TryParse(currentOrderNumStr, out int num) ? num : 0;
        bool isOrderNumberUnique = false;

        while (!isOrderNumberUnique)
        {
            currentOrderNumberInt++;
            string newOrderNumberTemp = newOrderNumber + currentOrderNumberInt.ToString("d10");
            string checkOrderNumber = newOrderNumberTemp;
            Order? order =await _orderRepository.Query().FirstOrDefaultAsync(o => o.OrderNumber == checkOrderNumber);
            if (order != null) continue;
            newOrderNumber = newOrderNumberTemp;
            isOrderNumberUnique = true;
        } 
    }
}