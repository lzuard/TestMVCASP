<template>
  <layout-full-page>
    <div class="auth-card rounded-3">
      <div class="row g-0">
        <div class="col-lg-6">
          <div class="auth-card__body">
            <preloader
              v-show="isLoading"
              :with-cover="true"
            />

            <div class="text-center">
              <box-icon class="auth-card__icon" />
              <h4 class="fw-bold text-uppercase mt-1 mb-3 pb-1">
                WareHouse Store
              </h4>
            </div>

            <auth-form @onSubmit="authenticateUser" />
          </div>
        </div>
        <auth-image />
      </div>
    </div>
  </layout-full-page>
</template>

<script>
import LayoutFullPage from '@/components/Layouts/layout-full-page'
import AuthImage from './AuthImage'
import AuthForm from './AuthForm'
import { BoxIcon } from '@iconicicons/vue3'

export default {
  name: 'Auth',
  components: {
    LayoutFullPage,
    AuthImage,
    AuthForm,
    BoxIcon
  },
  data: () => {
    return {
      isLoading: false
    }
  },
  methods: {
    authenticateUser (data) {
      this.isLoading = true

      this.$api.authorizeUser().then(() => {
        this.isLoading = false
      })
    }
  }
}
</script>

<style lang="scss">
@import "~@/styles/variables";
@import "~@/styles/mixins.scss";

.auth-card {
  @include boxShadow;
  background-color: $white;

  &__icon {
    width: 48px;
    height: 48px;
    color: $blue;
  }

  &__body {
    position: relative;
    padding: $gap-l;
  }
}

@media (min-width: 768px) {
  .gradient-form {
    height: 100vh !important;
  }
}
@media (min-width: 769px) {
  .gradient-custom {
    border-top-right-radius: .3rem;
    border-bottom-right-radius: .3rem;
  }
}
</style>
