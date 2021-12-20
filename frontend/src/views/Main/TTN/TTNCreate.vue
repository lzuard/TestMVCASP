<template>
  <showcase-create
    v-bind="createData"
    @onSend="createTTN($event)"
    ref="form"
  />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import { required } from '@/utils/validation/i18n-validators'
import { useToast } from 'vue-toastification'

export default {
  name: 'TTNCreate',
  components: {
    ShowcaseCreate
  },
  setup () {
    const toast = useToast()
    return { toast }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать ТТН',
        fields: [
          {
            label: 'Номер ТТН',
            placeholder: 'Номер',
            modelValue: 'number',
            cols: ['col-md-3'],
            validation: { required }
          },
          {
            label: 'Тип ТТН',
            placeholder: 'Тип ТТН',
            type: 'select',
            modelValue: 'type',
            cols: ['col-md-3'],
            validation: { required },
            values: [
              {
                text: 'Товарная',
                value: 0
              },
              {
                text: 'Товарно-транспортная',
                value: 1
              },
              {
                text: 'Накладная на отпуск материалов на сторону',
                value: 2
              },
              {
                text: 'Требование-накладная',
                value: 3
              }
            ]
          },
          {
            label: 'Форма ТТН',
            placeholder: 'УТП-12',
            modelValue: 'form',
            cols: ['col-md-3'],
            validation: { required }
          },
          {
            label: 'Дата оформления',
            type: 'date',
            modelValue: 'date',
            cols: ['col-md-3'],
            validation: { required }
          }
        ]
      }
    }
  },
  methods: {
    createTTN (data) {
      console.log(data)
      this.$api.ttn.createTTN(data)
        .then(() => {
          this.toast.success('ТТН успешно создан')
          this.$refs.form.clearForm()
        })
        .catch(() => {
          this.toast.error('Ошибка при создании ТТН, повторите позже')
        })
    }
  }
}
</script>
