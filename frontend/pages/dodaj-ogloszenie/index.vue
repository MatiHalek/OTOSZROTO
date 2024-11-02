<template>
    <div class="container mx-auto">
        <PageHeader>Dodaj ogłoszenie</PageHeader>

        <div class="pt-5 pb-96">
            <VerticalGroup class="gap-10">
                <HorizontalGroup class="gap-3">
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

                    <AppCheckBox class="mt-2">
                        Do negocjacji?
                    </AppCheckBox>
                </HorizontalGroup>

                <VerticalGroup>
                    <InputLabel for="description">Opis ogłoszenia: </InputLabel>
                    <AppTextArea id="description" v-model="newOfferData.description" />
                </VerticalGroup>

                <VerticalGroup class="gap-2">
                    <InputLabel>Zdjęcia (max 10): {{ files.length }} / 10 </InputLabel>

                    <button class="bg-[#FFF] border-2 border-[#DDD] w-60 h-24">Wybierz</button>
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
        </div>
    </div>
</template>

<script setup>

</script>