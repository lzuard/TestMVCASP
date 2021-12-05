<template>
  <div class="vh-100">
    <div class="container py-3 h-100">
      <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col col-xl-8">
          <slot />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'layout-full-page'
}
</script>
