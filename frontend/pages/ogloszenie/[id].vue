<template>

    <section class="bg-[#F3F3F3] dark:bg-[#0F172A] pb-36 md:pb-0">
        <div class="relative w-full h-[450px] overflow-hidden">
            <div class="absolute inset-0 w-full h-full overflow-hidden">
            <img
                :src="'http://localhost:5271/api/Uploads/gallery/' + imageSrcArray[currentIndex]"
                alt="Rozmyte tło"
                class="w-full h-full object-cover blur-md scale-110"
            />
            </div>
            <div class="relative w-full h-full flex items-center justify-center overflow-hidden">
            <div class="flex transition-transform duration-500 h-full w-full"
                :style="{ transform: `translateX(-${currentIndex * 100}%)` }">
                <div v-for="(image, index) in imageSrcArray" :key="index" class="min-w-full h-full flex justify-center">
                    <img :src="'http://localhost:5271/api/Uploads/gallery/'+ image" alt="Obrazek galerii" class="rounded-xl h-full w-full max-w-[1200px] object-cover" />
                </div>
            </div>
            </div>
            <button @click="prevImage" v-if="imageSrcArray.length > 1"
                    class="w-10 h-10 shadow-lg absolute top-1/2 left-4 transform -translate-y-1/2 bg-[#1e90ff] bg-opacity-75 text-white px-2 py-1 rounded-full hover:bg-opacity-100">
                <i class="fa-solid fa-caret-left"></i>
            </button>
            <button @click="nextImage" v-if="imageSrcArray.length > 1"
                    class="w-10 h-10 shadow-lg absolute top-1/2 right-4 transform -translate-y-1/2 bg-[#1e90ff] bg-opacity-75 text-white px-2 py-1 rounded-full hover:bg-opacity-100">
                <i class="fa-solid fa-caret-right"></i>
            </button>
        </div>
        <article class="relative container mx-auto px-4 lg:px-8" id="advertisementInfo">
            <section class="grid grid-cols-1 md:grid-cols-[minmax(0,_2.5fr)_minmax(250px,_1fr)] grid-flow-dense gap-4 -mt-16">
                <section class="z-10 flex flex-col items-center justify-center space-y-4 rounded-lg bg-[#D0D0D0CC] backdrop-blur-md md:backdrop-blur-none md:bg-white dark:bg-[#1E293B] p-3 break-all shadow-lg md:col-start-2 md:row-start-1 row-span-5 h-fit min-h-[8rem] fixed md:sticky md:top-24 break-normal bottom-0 w-full start-0">
                    <a :href="'mailto:' + data.data.email" class="flex relative min-h-[50px] items-center justify-center overflow-hidden text-[#FFF] py-2.5 px-5 rounded-full shadow-xl transition-all duration-300 before:absolute before:inset-0 before:border-[0px] before:border-white before:transition-all before:duration-300 before:ease-linear hover:bg-white hover:text-[#463691] before:rounded-full hover:shadow-special hover:before:border-[25px] font-bold bg-[#1e90ff] mt-0 shadow-xl w-11/12 cursor-pointer">
                        <span class="relative z-10">
                            <i class="fa-solid fa-envelope me-2"></i>{{ data.data.email }}
                        </span>
                    </a>
                    <a :href="'tel:' + data.data.phoneNumber" class="flex relative min-h-[50px] items-center justify-center overflow-hidden text-[#FFF] py-2.5 px-5 rounded-full shadow-xl transition-all duration-300 before:absolute before:inset-0 before:border-[0px] before:border-white before:transition-all before:duration-300 before:ease-linear hover:bg-white hover:text-[#463691] before:rounded-full hover:shadow-special hover:before:border-[25px] font-bold bg-[#43AD19] mt-0 shadow-xl w-11/12 cursor-pointer">
                        <span class="relative z-10">
                            <i class="fa-solid fa-phone me-2"></i>{{ data.data.phoneNumber }}
                        </span>
                    </a>

                    <hr class="w-full" v-if="currentOfferUserID == user.userId">

                    <AppManageAdvertisment v-if="currentOfferUserID == user.userId" />
                </section>

                <section class="rounded-lg bg-white dark:bg-[#1E293B] p-3 break-all shadow-lg">
                    <h1 class="text-2xl font-bold">{{ data.data.title }}
                        <span class="text-base font-normal">#{{ data.data.advertisementID.toString().padStart(6, "0") }}</span>
                    </h1>
                    <h2 class="text-lg text-gray-600 dark:text-gray-300 font-semibold">{{ data.data.category }}</h2>
                    <div class="flex justify-between flex-wrap mt-2">
                        <p class="mr-3 flex items-center"><i class="fa-solid fa-car me-2"></i> Stan: {{ data.data.condition }}</p>
                        <p class="flex items-center"><i class="fa-solid fa-calendar-days me-2"></i> Rok produkcji: {{ data.data.yearOfProduction }}</p>
                    </div>
                    <div class="mt-2">
                        <i class="fa-solid fa-calendar-day me-2"></i>Dodano: {{ new Intl.DateTimeFormat('pl-PL', { day: 'numeric', month: 'short', year: 'numeric' }).format(new Date(data.data.dateAdded))}}
                    </div>
                    <div class="text-center flex justify-center flex-col">
                        <h1 class="text-center text-2xl drop-shadow-lg font-bold text-white mix-blend-darken dark:mix-blend-lighten bg-gradient-to-br from-[#463691CC] from-40% to-[#E5A00ACC] mb-3 mt-8 mx-auto px-6 py-2 rounded-full">
                            <i class="fa-solid fa-sack-dollar me-2"></i>{{ data.data.price.toLocaleString('pl-PL', { useGrouping: true }) }} <small>PLN</small>       
                        </h1>
                        <p v-if="data.data.isPriceNegotiable" class="dark:brightness-[1.75] text-md font-bold text-transparent bg-gradient-to-br from-[#463691CC] from-40% to-[#E5A00ACC] bg-clip-text"><i class="fa-solid fa-circle-exclamation me-2"></i>Do negocjacji</p>
                    </div>          
                </section>
                <section class="rounded-lg bg-white dark:bg-[#1E293B] p-3 break-all shadow-lg">
                    <h4 class="text-center font-semibold text-2xl mb-4">Dane podstawowe</h4>
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-road"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600 dark:text-gray-300">Przebieg</strong>
                                <p>{{ data.data.mileage }} km</p>
                            </div>
                        </div>
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-gas-pump"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600 dark:text-gray-300">Rodzaj paliwa</strong>
                                <p>{{ data.data.fuelType }}</p>
                            </div>
                        </div>
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-gear"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600 dark:text-gray-300">Skrzynia biegów</strong>
                                <p>{{ data.data.gearbox }}</p>
                            </div>
                        </div>
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-truck-pickup"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600 dark:text-gray-300">Typ nadwozia</strong>
                                <p>{{ data.data.bodyType }}</p>
                            </div>
                        </div>
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-fire"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600 dark:text-gray-300">Pojemność skokowa</strong>
                                <p>{{ data.data.displacement }} cm<sup>3</sup></p>
                            </div>
                        </div>
                        <div class="flex jobInfo">
                            <div class="w-[30px] h-[30px] bg-gray-600 mt-2 rounded flex items-center justify-center jobInfoIcon text-white p-2">
                                <i class="fa-solid fa-bolt"></i>
                            </div>
                            <div class="ml-3">
                                <strong class="text-gray-600 dark:text-gray-300">Moc</strong>
                                <p>{{ data.data.power }} KM</p>
                            </div>
                        </div>
                    </div>
                </section>
                <section class="rounded-lg bg-white dark:bg-[#1E293B] p-3 break-all shadow-lg">
                    <h4 class="text-center font-semibold text-2xl mb-4">Opis</h4>
                    <p>{{ data.data.description }}</p>
                </section>
                <section class="rounded-lg bg-white dark:bg-[#1E293B] p-3 break-all shadow-lg">
                    <h4 class="text-center font-semibold text-2xl mb-4">Dane pozostałe</h4>
                    <table class="w-full">
                        <tbody>
                            <tr>
                                <td class="p-3 font-bold">Model</td>
                                <td class="p-3">{{ data.data.model }}</td>
                            </tr>
                            <tr class="bg-[#EEE] dark:bg-[#32344B]">
                                <td class="p-3 font-bold">Kolor</td>
                                <td class="p-3">{{ data.data.color }}</td>
                            </tr>
                            <tr>
                                <td class="p-3 font-bold">Liczba drzwi</td>
                                <td class="p-3">{{ data.data.numberOfDoors }}</td>
                            </tr>   
                            <tr class="bg-[#EEE] dark:bg-[#32344B]">
                                <td class="p-3 font-bold">Liczba miejsc</td>
                                <td class="p-3">{{ data.data.numberOfPlaces }}</td>
                            </tr>
                            <tr>
                                <td class="p-3 font-bold">VIN</td>
                                <td class="p-3">{{ data.data.vin }}</td>
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

    const { id } = useRoute().params;

    const user = useUserStore();
    const offers = useOffersStore();

    const currentOfferUserID = offers.offers.find(offer => offer.advertisementID == id).userID;

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

    const imageSrcArray = ref([]);
    const { data: images } = await useFetch(`http://localhost:5271/api/image/uploadGalleryImages/${id}`, { 
        responseType: 'json', 
        method: 'get',
        headers: {
            'Content-Type': 'application/json',
        } 
    });

    images.value.forEach(image => {
        imageSrcArray.value.push(image.imageSource);
    });

    //console.log(images.value);

    // for (const image of images.value) {
    //     const { data: singleImage } = await useFetch('http://localhost:5271/api/image/uploadGallerySingleImage', {
    //         responseType: 'arrayBuffer',
    //         method: 'post',
    //         body: JSON.stringify({
    //             ImagePath: image.imageSource
    //         }),
    //         headers: {
    //             'Content-Type': 'application/json',
    //         }
    //     });

    //     const mimeType = "image/png";
    //     const blob = new Blob([singleImage.value], { type: mimeType });

    //     if (typeof window !== 'undefined') {
    //         const reader = new FileReader();
    //         reader.onloadend = () => {
    //             const imageSrc = reader.result;
    //             imageSrcArray.value.push(imageSrc); 
    //             console.log(imageSrc); 
    //         };
    //         reader.readAsDataURL(blob);
    //     }
    // }

    useHead({
        title: data.value.data.title + ' | OTOSZROTO'
    });


    const currentIndex = ref(0);

    function nextImage() {
        currentIndex.value = (currentIndex.value + 1) % imageSrcArray.value.length;
    }

    function prevImage() {
    currentIndex.value =
        (currentIndex.value - 1 + imageSrcArray.value.length) % imageSrcArray.value.length;
    }
</script>