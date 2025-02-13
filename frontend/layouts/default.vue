<template>
   <div class="flex flex-col min-h-screen">
      <!-- place for Header -->
     <Header />

     <main class="grow dark:bg-[#0F172A] dark:text-white">
        <slot />
     </main>

      <!-- place for Footer -->
       <Footer />
   </div> 
</template>