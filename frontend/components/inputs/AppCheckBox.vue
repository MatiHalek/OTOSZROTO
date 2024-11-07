<template>
    <HorizontalGroup class="pt-5">
        <input type="checkbox" id="checkbox" v-model="model">
        <label for="checkbox" class="pl-2 text-[#332404]">
            <slot />
        </label>
    </HorizontalGroup>

    <!-- for tests only -->
    <!-- <h2>{{ model }}</h2> -->
</template>

<script setup>
    const model = defineModel();
</script>