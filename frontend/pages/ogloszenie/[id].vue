<template>
    <section class="bg-[#F3F3F3] pb-36 md:pb-0">
	    <img class="w-full h-[450px] object-cover" src="https://wallpaperaccess.com/full/1673840.jpg">
        <article class="container mx-auto px-4 lg:px-8" id="advertisementInfo">
            <section class="grid grid-cols-1 md:grid-cols-[minmax(0,_2.5fr)_minmax(250px,_1fr)] grid-flow-dense gap-4 -mt-16">
                <section class="flex flex-col items-center justify-center space-y-4 rounded-lg bg-[#D0D0D090] backdrop-blur-md md:backdrop-blur-none md:bg-white p-3 break-all shadow-lg md:col-start-2 md:row-start-1 row-span-5 h-fit min-h-[8rem] fixed md:sticky md:top-24 break-normal bottom-0 w-full start-0">
                    <a href="mailto:" class="flex relative min-h-[50px] items-center justify-center overflow-hidden text-[#FFF] p-2.5 rounded-lg shadow-xl transition-all duration-300 before:absolute before:inset-0 before:border-[0px] before:border-white before:transition-all before:duration-300 before:ease-linear hover:bg-white hover:text-[#463691] hover:shadow-special hover:before:border-[25px] font-bold bg-[#1e90ff] mt-0 shadow-xl w-11/12 cursor-pointer">
                        <span class="relative z-10">
                            <i class="fa-solid fa-envelope me-2"></i>email
                        </span>
                    </a>
                    <a href="tel:" class="flex relative min-h-[50px] items-center justify-center overflow-hidden text-[#FFF] p-2.5 rounded-lg shadow-xl transition-all duration-300 before:absolute before:inset-0 before:border-[0px] before:border-white before:transition-all before:duration-300 before:ease-linear hover:bg-white hover:text-[#463691] hover:shadow-special hover:before:border-[25px] font-bold bg-[#43AD19] mt-0 shadow-xl w-11/12 cursor-pointer">
                        <span class="relative z-10">
                            <i class="fa-solid fa-phone me-2"></i>phoneNumber
                        </span>
                    </a>
                </section>
                <section class="rounded-lg bg-white p-3 break-all shadow-lg">
                    <h1 class="text-2xl font-bold">Tytuł
                        <span class="text-base font-normal">#000001</span>
                    </h1>
                    <h2 class="text-lg text-gray-600 font-semibold">Kategoria</h2>
                    <div class="flex justify-between flex-wrap mt-2">
                        <p class="mr-3 flex items-center"><i class="fa-solid fa-car me-2"></i> Stan: condition</p>
                        <p class="flex items-center"><i class="fa-solid fa-calendar-days me-2"></i> Rok produkcji: yearOfProduction</p>
                    </div>
                    <div class="text-center flex justify-center flex-col">
                        <h1 class="text-center text-2xl drop-shadow-lg font-bold text-white mix-blend-darken bg-gradient-to-br from-[#463691CC] from-40% to-[#E5A00ACC] mb-3 mt-8 mx-auto px-6 py-2 rounded-full">
                            <i class="fa-solid fa-sack-dollar me-2"></i>price               
                        </h1>
                        <p class="text-md font-bold text-transparent bg-gradient-to-br from-[#463691CC] from-40% to-[#E5A00ACC] bg-clip-text"><i class="fa-solid fa-circle-exclamation me-2"></i>Do negocjacji</p>
                    </div>          
                </section>
                <section class="rrounded-lg bg-white p-3 break-all shadow-lg">
                    <h4 class="text-center font-semibold text-2xl mb-4">Dane podstawowe</h4>
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-road"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600">Przebieg</strong>
                                <p>mileage</p>
                            </div>
                        </div>
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-gas-pump"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600">Rodzaj paliwa</strong>
                                <p>fuelType</p>
                            </div>
                        </div>
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-gear"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600">Skrzynia biegów</strong>
                                <p>gearBox</p>
                            </div>
                        </div>
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-truck-pickup"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600">Typ nadwozia</strong>
                                <p>bodyType</p>
                            </div>
                        </div>
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-fire"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600">Pojemność skokowa</strong>
                                <p>displacement</p>
                            </div>
                        </div>
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-bolt"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600">Moc</strong>
                                <p>power</p>
                            </div>
                        </div>
                    </div>
                </section>
                <section class="rounded-lg bg-white p-3 break-all shadow-lg">
                    <h4 class="text-center font-semibold text-2xl mb-4">Opis</h4>
                    <p>description</p>
                </section>
                <section class="rounded-lg bg-white p-3 break-all shadow-lg">
                    <h4 class="text-center font-semibold text-2xl mb-4">Dane pozostałe</h4>
                    <table class="w-full">
                        <tbody>
                            <tr>
                                <td class="p-3 font-bold">data1</td>
                                <td class="p-3">data2</td>
                            </tr>
                            <tr class="bg-[#EEE]">
                                <td class="p-3 font-bold">data3</td>
                                <td class="p-3">data4</td>
                            </tr>
                            <tr>
                                <td class="p-3 font-bold">data5</td>
                                <td class="p-3">data6</td>
                            </tr>   
                        </tbody>                    
                    </table>
                </section>
            </section>				
        </article>
    </section>
</template>

<script setup>
    definePageMeta({
        layout: 'default'
    });
    useHead({
        title: '[tytuł] | OTOSZROTO'
    });
</script>