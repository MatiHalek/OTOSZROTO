<template>
    <div class="flex">
         <h2>{{ image.name }}</h2>
         <h3>{{ formatFileSize(image.size) }}</h3>
    </div>
</template>

<script setup>
    defineProps(['image']);

    function formatFileSize(bytes) {
        if (bytes >= 1024 * 1024) {
            return `${(bytes / (1024 * 1024)).toFixed(2)} MB`;
        } else {
            return `${(bytes / 1024).toFixed(2)} KB`;
        }
    }
</script>
