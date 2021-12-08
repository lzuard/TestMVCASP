<template>
  <form @submit.prevent class="auth-form">
    <p>Пожалуйста, войдите в аккаунт</p>

    <div class="auth-form__field form-outline mb-2">
      <input-field v-model="v$.login.$model" placeholder="Логин" />
      <layout-alert class="auth-form__error" type="danger" v-if="v$.login.$error">
        Логин обязателен к заполнению
      </layout-alert>
    </div>

    <div class="auth-form__field form-outline mb-2">
      <input-field v-model="v$.password.$model" placeholder="Пароль" type="password" />
      <layout-alert class="auth-form__error" type="danger" v-if="v$.password.$error">
        Пароль обязателен к заполнению
      </layout-alert>
    </div>

    <div class="text-center pt-1 mb-3 pb-1">
      <layout-button
        class="w-100"
        :is-gradient="true"
        @click="onSubmit"
      >
        Войти
      </layout-button>
    </div>

    <div class="auth-form__forget">
      Проблемы со входом в аккаунт? <br>
      Обратитесь к системному администратору
    </div>
  </form>
</template>

<script>
import { required } from '@vuelidate/validators'
import { useVuelidate } from '@vuelidate/core'
import LayoutButton from '@/components/Layouts/layout-button'
import InputField from '@/components/UI/inputField'
import LayoutAlert from '@/components/Layouts/layout-alert'

export default {
  name: 'AuthForm',
  components: {
    LayoutButton,
    InputField,
    LayoutAlert
  },
  setup () {
    return { v$: useVuelidate() }
  },
  data () {
    return {
      login: '',
      password: ''
    }
  },
  validations () {
    return {
      login: { required },
      password: { required }
    }
  },
  methods: {
    async onSubmit () {
      const isFormCorrect = await this.v$.$validate()
      if (isFormCorrect) {
        this.$emit('onSubmit', { login: this.login, password: this.password })
      }
    }
  }
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.auth-form {
  &__forget {
    font-size: $font-size-xs;
    font-weight: 600;
    color: $blue;
  }
}
</style>
