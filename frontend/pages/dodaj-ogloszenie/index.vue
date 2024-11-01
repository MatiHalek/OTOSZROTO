<template>
    <div class="container mx-auto">
        <PageHeader>Dodaj ogłoszenie</PageHeader>

        <form class="pt-5 pb-96">
            <VerticalGroup class="gap-10">
                <HorizontalGroup class="gap-3">
                    <VerticalGroup class="flex-1">
                        <InputLabel for="title">Tytuł ogłoszenia: </InputLabel>
                        <AppDetailsInput id="title" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="category">Kategoria ogłoszenia: </InputLabel>
                        <AppSelectBox :source="['Samochody osobowe', 'Motocykle']" class="w-64" />
                    </VerticalGroup>
                </HorizontalGroup>

                <HorizontalGroup class="items-center gap-5">
                    <VerticalGroup>
                        <InputLabel for="price">Cena: (PLN)</InputLabel>
                        <AppDetailsInput id="price" />
                    </VerticalGroup>

                    <AppCheckBox class="mt-2">
                        Do negocjacji?
                    </AppCheckBox>
                </HorizontalGroup>

                <VerticalGroup>
                    <InputLabel for="description">Opis ogłoszenia: </InputLabel>
                    <AppTextArea id="description" />
                </VerticalGroup>

                <VerticalGroup>
                    <InputLabel>Zdjęcia (max 10): </InputLabel>

                    <button class="bg-[#FFF] border-2 border-[#DDD] w-60 h-24">Wybierz</button>
                </VerticalGroup>

                <VerticalGroup>
                    <hr class="pb-5">
                    <h2 class="text-2xl m-0 font-medium">Szczegóły</h2>
                </VerticalGroup>

                <VerticalGroup class="flex-1">
                    <InputLabel for="model">Model pojazdu: </InputLabel>
                    <AppDetailsInput id="model" />
                </VerticalGroup>

                <HorizontalGroup class="gap-5 flex-col md:flex-row">
                    <VerticalGroup>
                        <InputLabel for="year">Rok produkcji: </InputLabel>
                        <AppDetailsInput id="year" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="doors">Liczba drzwi: </InputLabel>
                        <AppDetailsInput id="doors" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="space">Liczba miejsc: </InputLabel>
                        <AppDetailsInput id="space" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="color">Kolor: </InputLabel>
                        <AppDetailsInput id="color" />
                    </VerticalGroup>

                    <VerticalGroup class="flex-none lg:flex-1">
                        <InputLabel for="vin">VIN: </InputLabel>
                        <AppDetailsInput id="vin" />
                    </VerticalGroup>
                </HorizontalGroup>

                <VerticalGroup>
                    <hr class="pb-5 mt-16">
                    <h2 class="text-2xl m-0 font-medium">Specyfikacja</h2>
                </VerticalGroup>

                <HorizontalGroup class="gap-5 flex-col lg:flex-row">
                    <VerticalGroup>
                        <InputLabel for="power">Moc: </InputLabel>
                        <AppDetailsInput id="power" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="displacement">Pojemność skokowa: </InputLabel>
                        <AppDetailsInput id="displacement" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="gearbox">Skrzynia biegów: </InputLabel>
                        <AppSelectBox :source="['manualna', 'automatyczna', 'PDK']" id="gearbox" class="w-48" />
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="fuel">Rodzaj paliwa: </InputLabel>
                        <AppSelectBox :source="['benzyna', 'diesel', 'instalacja gazowa']" id="fuel" class="w-48"/>
                    </VerticalGroup>

                    <VerticalGroup>
                        <InputLabel for="body">Typ nadwozia: </InputLabel>
                        <AppSelectBox :source="['SUV', 'Coupe', 'Combi']" id="body"  class="w-48"/>
                    </VerticalGroup>
                </HorizontalGroup>

                <VerticalGroup>
                    <hr class="pb-5 mt-16">
                    <h2 class="text-2xl m-0 font-medium">Stan</h2>
                </VerticalGroup>

                <HorizontalGroup class="gap-5">
                    <VerticalGroup>
                        <InputLabel for="condition">Stan: </InputLabel>
                        <AppSelectBox :source="['Nowy', 'Używany']" id="condition" class="w-48" />
                    </VerticalGroup>

                    <VerticalGroup class="flex-1">
                        <InputLabel for="mileage">Przebieg: </InputLabel>
                        <AppDetailsInput id="mileage" />
                    </VerticalGroup>
                </HorizontalGroup>
            </VerticalGroup>
        </form>
    </div>
</template>

<script setup>

</script>