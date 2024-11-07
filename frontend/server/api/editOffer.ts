export default defineEventHandler(async (event) => {
    const body = await readBody(event);

        const response = await $fetch(`http://localhost:5271/api/advertisment/${body.id}`, 
        { 
            responseType: 'json', 
            method: 'put', 
            body: {
                "Title": body.offerData.title,
                "Price": body.offerData.price,
                "Description": body.offerData.description,
                "Model": body.offerData.model,
                "Category": body.offerData.category,
                "YearOfProduction": body.offerData.yearOfProduction,
                "IsPriceNegotiable": body.offerData.forNegotiation,
                "NumberOfDoors": body.offerData.numberOfDoors,
                "NumberOfPlaces": body.offerData.numberOfPlaces,
                "Color": body.offerData.color,
                "VIN": body.offerData.VIN,
                "Power": body.offerData.power,
                "Displacement": body.offerData.displacement,
                "Gearbox": body.offerData.gearbox,
                "FuelType": body.offerData.fuelType,
                "BodyType": body.offerData.bodyType,
                "Condition": body.offerData.condition,
                "Mileage": body.offerData.mileage,
                "Email": body.offerData.email,
                "PhoneNumber": body.offerData.phoneNumber,
                "UserID": body.offerData.userID
            },
        });

    return {
        'value': response
    }
})