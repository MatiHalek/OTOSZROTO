<template>
    <Transition name="fade">
        <div class="fixed left-0 top-0 z-50 w-full h-full bg-[#00000095] flex justify-center items-center" v-show="isVisible">
            <Transition>
                <div class="bg-[#fff] dark:bg-black dark:text-white h-96 w-[540px] rounded-lg relative py-14 px-8" v-if="isVisible">
                    <div>
                        <h2 class="text-center font-bold text-3xl">Czy na pewno chcesz usunąć tę ofertę?</h2>
                        <h3 class="text-center py-3 text-base">Oferta nie będzie mogła zostać przywrócona!</h3>

                        <div class="flex flex-col mt-20 gap-3">
                            <button class="w-full bg-[#E32727] p-2 text-[#FFF] rounded-full hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300" @click="deleteOffer()">Usuń</button>
                            <button @click="$emit('close')" class="w-full bg-[#DDD] dark:bg-[#333] p-2 rounded-full hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300">Anuluj</button>
                        </div>
                    </div>
                </div>
            </Transition>
        </div>
    </Transition>
</template>

<script setup>
    const props = defineProps(['isVisible', 'id']);

    async function deleteOffer() {
        if(props.id) {
            const response = await $fetch(`/api/test`, {
                method: 'post',
                body: {
                    id: props.id
                }
            });

            if(response) {
                const offers = useOffersStore();
                offers.getOffers();

                await navigateTo('/');
            }

            console.log(response);
        }
    }
</script>

<style scoped>
    .v-enter-active,
    .v-leave-active {
        transition: all .3s cubic-bezier(0.24,0.07,0.09,0.99);
    }

    .v-enter-from,
    .v-leave-to {
        transform: scale(.8);
        opacity: 0;
        transform-origin: center;
    }

    .fade-enter-active,
    .fade-leave-active {
        transition: opacity .3s cubic-bezier(0.24,0.07,0.09,0.99);
    }

    .fade-enter-from,
    .fade-leave-to {
        opacity: 0;
    }
</style>