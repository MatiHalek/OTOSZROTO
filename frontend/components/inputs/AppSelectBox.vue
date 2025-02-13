<template>
    <div 
        @click="isCollapsed = !isCollapsed" 
        class="rounded-lg relative h-10 p-1.5 border-2 border-[#DDD] cursor-pointer whitespace-nowrap w-52 flex items-center justify-between"
        :class="{ 'bg-gray-200': !selected }"
    >
        <p v-if="selected">{{ selected }}</p>
        <p class="dark:text-black" v-else>Wybierz...</p>
        <i class="fa-solid ms-2" :class="{'fa-chevron-down' : !isCollapsed, 'fa-chevron-up' : isCollapsed}"></i>

        <div v-if="isCollapsed" class="shadow-lg w-full bg-white dark:bg-[#000] z-10 absolute -left-[1px] flex flex-col gap-1 border-[1px] border-[#DDD] border-t-0 top-[38px]">
            <div v-for="(item, index) in source" :key="index" @click="selectItem(item)" class="p-3 cursor-pointer w-full bg-[#fdfdfd] dark:bg-[#222] hover:bg-[#EEE] dark:hover:bg-[#444]">
                {{ item }}
            </div>
        </div>
    </div>
</template>

<script setup>

const props = defineProps({
    source: Array,
    current: String,
    indexSelected: Number
});

const emit = defineEmits(['selectionChanged']);

const selected = ref('');
const isCollapsed = ref(false);

onMounted(() => {
    if (props.indexSelected !== undefined && props.source[props.indexSelected] !== undefined) {
        selected.value = props.source[props.indexSelected];
    } else {
        selected.value = props.current;
    }
});

function selectItem(item) {
    selected.value = item;
    emit('selectionChanged', selected.value);
}
</script>
