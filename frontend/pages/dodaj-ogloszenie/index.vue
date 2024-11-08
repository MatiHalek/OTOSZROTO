<template>
    <div class="container mx-auto p-10 sm:p-0">
        <PageHeader>Dodaj ogłoszenie</PageHeader>

        <div class="pt-5 pb-96">
            <VerticalGroup class="gap-10">
                <HorizontalGroup class="gap-3 flex-col sm:flex-row">
                    <VerticalGroup class="flex-1">
                        <InputLabel for="title">Tytuł ogłoszenia: </InputLabel>
                        <AppDetailsInput v-model="newOfferData.title" id="title" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="category">Kategoria ogłoszenia: </InputLabel>
                        <AppSelectBox @selectionChanged="(value) => { newOfferData.category = value }" :source="['Samochody osobowe', 'Motocykle']" class="w-64" />
                    </VerticalGroup>
                </HorizontalGroup>

                <HorizontalGroup class="items-center gap-5">
                    <VerticalGroup>
                        <InputLabel for="price">Cena: (PLN)</InputLabel>
                        <AppDetailsInput v-model="newOfferData.price" id="price" />
                    </VerticalGroup>

                    <AppCheckBox class="mt-2" v-model="newOfferData.forNegotiation">
                        Do negocjacji?
                    </AppCheckBox>
                </HorizontalGroup>

                <VerticalGroup>
                    <InputLabel for="description">Opis ogłoszenia: </InputLabel>
                    <AppTextArea id="description" v-model="newOfferData.description" />
                </VerticalGroup>

                <VerticalGroup class="gap-2">
                    <InputLabel>Zdjęcia (max 10): {{ files.length }} / 10 </InputLabel>

                    <label :class="{ 'hidden': files.length >= 10 }" for="file-input" class="bg-[#FFF] border-2 border-[#DDD] w-60 h-24 flex justify-center items-center cursor-pointer">
                        <button>Wybierz</button>
                    </label>

                    <input class="hidden" type="file" id="file-input" @change="handleFileUpload" ref="fileInput" accept="image/*">
                    
                    <AppSelectedImages v-for="(image, index) in files" :image="image" @deleteImage="files.splice(index, 1);"/>
                </VerticalGroup>

                <VerticalGroup>
                    <hr class="pb-5">
                    <h2 class="text-2xl m-0 font-medium">Szczegóły</h2>
                </VerticalGroup>

                <VerticalGroup class="flex-1">
                    <InputLabel for="model">Model pojazdu: </InputLabel>
                    <AppDetailsInput v-model="newOfferData.model" id="model" />
                </VerticalGroup>

                <HorizontalGroup class="gap-5 flex-col md:flex-row">
                    <VerticalGroup>
                        <InputLabel for="year">Rok produkcji: </InputLabel>
                        <AppDetailsInput v-model="newOfferData.yearOfProduction" id="year" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="doors">Liczba drzwi: </InputLabel>
                        <AppDetailsInput v-model="newOfferData.numberOfDoors" id="doors" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="space">Liczba miejsc: </InputLabel>
                        <AppDetailsInput v-model="newOfferData.numberOfPlaces" id="space" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="color">Kolor: </InputLabel>
                        <AppDetailsInput v-model="newOfferData.color" id="color" />
                    </VerticalGroup>

                    <VerticalGroup class="flex-none lg:flex-1">
                        <InputLabel for="vin">VIN: </InputLabel>
                        <AppDetailsInput v-model="newOfferData.VIN" id="vin" />
                    </VerticalGroup>
                </HorizontalGroup>

                <VerticalGroup>
                    <hr class="pb-5 mt-16">
                    <h2 class="text-2xl m-0 font-medium">Specyfikacja</h2>
                </VerticalGroup>

                <HorizontalGroup class="gap-5 flex-col lg:flex-row">
                    <VerticalGroup>
                        <InputLabel for="power">Moc: </InputLabel>
                        <AppDetailsInput v-model="newOfferData.power" id="power" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="displacement">Pojemność skokowa: </InputLabel>
                        <AppDetailsInput v-model="newOfferData.displacement" id="displacement" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="gearbox">Skrzynia biegów: </InputLabel>
                        <AppSelectBox @selectionChanged="(value) => { newOfferData.gearbox = value }" :source="['manualna', 'automatyczna', 'PDK']" id="gearbox" class="w-48" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="fuel">Rodzaj paliwa: </InputLabel>
                        <AppSelectBox @selectionChanged="(value) => { newOfferData.fuelType = value }" :source="['benzyna', 'diesel', 'instalacja gazowa']" id="fuel" class="w-48"/>
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="body">Typ nadwozia: </InputLabel>
                        <AppSelectBox @selectionChanged="(value) => { newOfferData.bodyType = value }" :source="['SUV', 'Coupe', 'Combi']" id="body"  class="w-48"/>
                    </VerticalGroup>
                </HorizontalGroup>

                <VerticalGroup>
                    <hr class="pb-5 mt-16">
                    <h2 class="text-2xl m-0 font-medium">Stan</h2>
                </VerticalGroup>

                <HorizontalGroup class="gap-5">
                    <VerticalGroup>
                        <InputLabel for="condition">Stan: </InputLabel>
                        <AppSelectBox @selectionChanged="(value) => { newOfferData.condition = value }" :source="['Nowy', 'Używany']" id="condition" class="w-48" />
                    </VerticalGroup>

                    <VerticalGroup class="flex-1">
                        <InputLabel for="mileage">Przebieg: </InputLabel>
                        <AppDetailsInput v-model="newOfferData.mileage" id="mileage" />
                    </VerticalGroup>
                </HorizontalGroup>
            </VerticalGroup>

            <ConfirmButton class="mt-24 w-48" @click="createOffer()">Wyślij</ConfirmButton>
        </div>
    </div>
</template>

<script setup>
    const user = useUserStore();

    const newOfferData = ref({
        title: '',
        price: 0,
        category: '',
        forNegotiation: false,
        description: '',
        image: [],
        model: '',
        yearOfProduction: 0,
        numberOfDoors: 0,
        numberOfPlaces: 0,
        color: '',
        VIN: '',
        power: 0,
        displacement: 0,
        gearbox: '',
        fuelType: '',
        bodyType: '',
        condition: '',
        mileage: 0,
        email: user.email,
        phoneNumber: user.phone
    });

    const files = ref([]);
    const allowedTypes = ref(['image/jpeg', 'image/png']);
    const fileInput = ref(null);
    const fileError = ref();

    function handleFileUpload(event) {
        const selectedFiles = Array.from(event.target.files);
        fileError.value = '';

        selectedFiles.forEach(file => {
            if(!allowedTypes.value.includes(file.type)) {
                fileError.value = 'Nieprawidłowy typ zdjęcia!';
            } else {
                files.value.push(file);
            }
        });
    }

    async function createOffer() {
        const response = await $fetch('http://localhost:5271/api/advertisment', 
        { 
            responseType: 'json', 
            method: 'post', 
            body: {
                "Title": newOfferData.value.title,
                "Price": newOfferData.value.price,
                "Description": newOfferData.value.description,
                "Model": newOfferData.value.model,
                "Category": newOfferData.value.category,
                "IsPriceNegotiable": newOfferData.value.forNegotiation,
                "YearOfProduction": newOfferData.value.yearOfProduction,
                "NumberOfDoors": newOfferData.value.numberOfDoors,
                "NumberOfPlaces": newOfferData.value.numberOfPlaces,
                "Color": newOfferData.value.color,
                "VIN": newOfferData.value.VIN,
                "Power": newOfferData.value.power,
                "Displacement": newOfferData.value.displacement,
                "Gearbox": newOfferData.value.gearbox,
                "FuelType": newOfferData.value.fuelType,
                "BodyType": newOfferData.value.bodyType,
                "Condition": newOfferData.value.condition,
                "Mileage": newOfferData.value.mileage,
                "Email": newOfferData.value.email,
                "PhoneNumber": newOfferData.value.phoneNumber,
                "UserID": user.userId
            },
        });

        if(response) {
            const offers = useOffersStore();
            offers.getOffers();

            const formData = new FormData();
            files.value.forEach(file => formData.append('files', file));

            const imagesResponse = await $fetch(`http://localhost:5271/api/image/uploadGalleryImages/${response.advertisementID}`, { responseType: 'json', method: 'post', body: formData });

            await navigateTo('/ogloszenie/' + response.advertisementID);
        }
    }
</script>