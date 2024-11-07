<template>
    <div @click="isCollapsed = !isCollapsed" class="relative h-10 p-1.5 border-2 border-[#DDD] cursor-pointer whitespace-nowrap">
        <p v-if="selected">{{ selected }}</p>
        <p v-else>wybierz</p>

        <div v-if="isCollapsed" class="w-full bg-[#] z-10 absolute -left-[1px] flex flex-col gap-1 border-[1px] border-[#DDD] border-t-0 top-[38px]">
            <div v-for="item in source" @click="selectItem(item)" class="p-3 cursor-pointer w-full bg-[#fdfdfd] hover:bg-[#EEE]">
                {{ item }}
            </div>
        </div>
    </div>
    <br>
</template>

<script setup>
    //props 

    const props = defineProps(['source', 'current']);

    // emits
    const emit = defineEmits(['selectionChanged']);

    const selected = ref('');
    selected.value = props.current;

    const isCollapsed = ref(false);

    function selectItem(item) {
        selected.value = item;

        emit('selectionChanged', selected.value);
    }
</script>