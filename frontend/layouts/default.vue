<template>
   <div class="flex flex-col min-h-screen">
      <!-- place for Header -->
     <Header />

     <main class="grow">
        <slot />
     </main>

      <!-- place for Footer -->
       <Footer />
   </div> 
</template>