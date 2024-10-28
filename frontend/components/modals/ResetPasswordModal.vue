<template>
    <Transition name="fade">
        <div class="fixed left-0 top-0 z-50 w-full h-full bg-[#00000095] flex justify-center items-center" v-show="isVisible">
            <Transition>
                <div class="bg-[#fff] h-96 w-96 rounded-sm relative pt-0 pr-5 pb-5" v-if="isVisible">
                    <svg class="absolute left-4 top-4 w-6 cursor-pointer fill-[#231D2B] transition-colors hover:fill-[#F44534]" @click="$emit('close')" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512"><!--!Font Awesome Free 6.5.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2024 Fonticons, Inc. -->
                        <path d="M342.6 150.6c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0L192 210.7 86.6 105.4c-12.5-12.5-32.8-12.5-45.3 0s-12.5 32.8 0 45.3L146.7 256 41.4 361.4c-12.5 12.5-12.5 32.8 0 45.3s32.8 12.5 45.3 0L192 301.3 297.4 406.6c12.5 12.5 32.8 12.5 45.3 0s12.5-32.8 0-45.3L237.3 256 342.6 150.6z"/>
                    </svg>

                    <div id="content">
                        
                    </div>
                </div>
            </Transition>
        </div>
    </Transition>
</template>

<script setup>
    const props = defineProps(['isVisible']);
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