<template>
    <div class="container mx-auto">
        <PageHeader>Edytuj ogłoszenie #{{ $route.params.id.padStart(6, "0") }}</PageHeader>

        <div class="pt-5 pb-96">
            <form ref="editForm">
                <VerticalGroup class="gap-10">
                    <HorizontalGroup class="gap-3 flex-col sm:flex-row">
                        <VerticalGroup class="flex-1">
                            <InputLabel for="title">Tytuł ogłoszenia: </InputLabel>
                            <AppDetailsInput v-model="newOfferData.title" id="title" />
                        </VerticalGroup>

                        <VerticalGroup>
                            <InputLabel for="category">Kategoria ogłoszenia: </InputLabel>
                            <AppSelectBox @selectionChanged="(value) => { newOfferData.category = value }" :source="['Samochody osobowe', 'Motocykle']" :current="newOfferData.category" class="w-64" />
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
                        <InputLabel>Zdjęcia (max 10): </InputLabel>

                        <label for="file-input" class="bg-[#FFF] border-2 border-[#DDD] w-60 h-24 flex justify-center items-center cursor-pointer">
                            <button>Wybierz</button>
                        </label>

                        <input class="hidden" type="file" id="file-input" @change="handleFileUpload" ref="fileInput" accept="image/*">
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
                            <AppSelectBox @selectionChanged="(value) => { newOfferData.gearbox = value }" :source="['manualna', 'automatyczna', 'PDK']" :current="newOfferData.gearbox" id="gearbox" class="w-48" />
                        </VerticalGroup>

                        <VerticalGroup>
                            <InputLabel for="fuel">Rodzaj paliwa: </InputLabel>
                            <AppSelectBox @selectionChanged="(value) => { newOfferData.fuelType = value }" :source="['benzyna', 'diesel', 'instalacja gazowa']" :current="newOfferData.fuelType" id="fuel" class="w-48"/>
                        </VerticalGroup>

                        <VerticalGroup>
                            <InputLabel for="body">Typ nadwozia: </InputLabel>
                            <AppSelectBox @selectionChanged="(value) => { newOfferData.bodyType = value }" :source="['SUV', 'Coupe', 'Combi']" :current="newOfferData.bodyType" id="body"  class="w-48"/>
                        </VerticalGroup>
                    </HorizontalGroup>

                    <VerticalGroup>
                        <hr class="pb-5 mt-16">
                        <h2 class="text-2xl m-0 font-medium">Stan</h2>
                    </VerticalGroup>

                    <HorizontalGroup class="gap-5">
                        <VerticalGroup>
                            <InputLabel for="condition">Stan: </InputLabel>
                            <AppSelectBox @selectionChanged="(value) => { newOfferData.condition = value }" :source="['Nowy', 'Używany']" :current="newOfferData.condition" id="condition" class="w-48" />
                        </VerticalGroup>

                        <VerticalGroup class="flex-1">
                            <InputLabel for="mileage">Przebieg: </InputLabel>
                            <AppDetailsInput v-model="newOfferData.mileage" id="mileage" />
                        </VerticalGroup>
                    </HorizontalGroup>
                </VerticalGroup>

                <ConfirmButton type="submit" class="mt-24 w-48" @click.prevent="editOffer()">Edytuj</ConfirmButton>
            </form>
        </div>
    </div>
</template>

<script setup>
    useHead({
        title: 'Edytuj ogłoszenie | OTOSZROTO'
    });
    const { id } = useRoute().params;

    const { data } = await useFetch('/api/getOffers', { 
        responseType: 'json', 
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
        },
        body: {
            'id': id
        }
    });

    // const { data: images } = await useFetch(`http://localhost:5271/api/image/uploadGalleryImages/${id}`, { 
    //     responseType: 'json', 
    //     method: 'get',
    //     headers: {
    //         'Content-Type': 'application/json',
    //     } 
    // });

    // const files = ref([]);
    // const formData = new FormData();
    // const imageSrc = ref(null); // Ustawienie na null na początku

    // const { data: singleImage } = await useFetch('http://localhost:5271/api/image/uploadGallerySingleImage', { 
    //     responseType: 'arrayBuffer', 
    //     method: 'post',
    //     body: JSON.stringify({
    //         ImagePath: images.value[0].imageSource
    //     }),
    //     headers: {
    //         'Content-Type': 'application/json',
    //     }
    // });

    // onMounted(async () => {
    //     const mimeType = "image/png";
    //     const blob = new Blob([singleImage.value], { type: mimeType });
    //     const file = new File([blob], images.value[0].imageSource.split('/').pop(), { type: mimeType });
    //     files.value.push(file);

    //     if (typeof window !== 'undefined') {
    //         const reader = new FileReader();
    //         reader.onloadend = () => {
    //             imageSrc.value = reader.result; 
    //             console.log(singleImage.value); 
    //         };
    //         reader.readAsDataURL(blob); 
    //     }
    // });

    const user = useUserStore();

    const newOfferData = ref({
        title: data.value.data.title,
        price: data.value.data.price,
        category: data.value.data.category,
        forNegotiation: data.value.data.isPriceNegotiable,
        description: data.value.data.description,
        image: [],
        model: data.value.data.model,
        yearOfProduction: data.value.data.yearOfProduction,
        numberOfDoors: data.value.data.numberOfDoors,
        numberOfPlaces: data.value.data.numberOfPlaces,
        color: data.value.data.color,
        VIN: data.value.data.vin,
        power: data.value.data.power,
        displacement: data.value.data.displacement,
        gearbox: data.value.data.gearbox,
        fuelType: data.value.data.fuelType,
        bodyType: data.value.data.bodyType,
        condition: data.value.data.condition,
        mileage: data.value.data.mileage,
        email: data.value.data.email,
        phoneNumber: data.value.data.phoneNumber,
        userID: user.userId
    });

    const allowedTypes = ref(['image/jpeg', 'image/png']);
    const fileInput = ref(null);
    const fileError = ref();
    const editForm = ref(null);

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

    async function editOffer() {
        if(editForm.value.reportValidity() === false) return;
        const response = await $fetch(`/api/editOffer`, {
            method: 'post',
            body: {
                id: id,
                offerData: newOfferData.value
            }
        });

        if(response) {
            const offers = useOffersStore();
            offers.getOffers();

            await navigateTo('/ogloszenie/' + response.value.advertisementID);
        }

        console.log(response.value);

       // if(response) {
            //const formData = new FormData();
            //files.value.forEach(file => formData.append('files', file));

            //const imagesResponse = await $fetch(`http://localhost:5271/api/image/uploadGalleryImages/${response.advertisementID}`, { responseType: 'json', method: 'post', body: formData });
        //}
    }
</script>