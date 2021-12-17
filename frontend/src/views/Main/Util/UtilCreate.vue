<template>
  <showcase-create v-bind="createData" />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import { required } from '@/utils/validation/i18n-validators'

export default {
  name: 'AgentCreate',
  components: {
    ShowcaseCreate
  },
  data: () => {
    return {
      createData: {
        title: 'Создать утилизацию',
        fields: [
          {
            label: 'Номер ТТН',
            placeholder: 'ТТН',
            modelValue: 'ttnNumber',
            cols: ['col-md-4'],
            validation: { required }
          },
          {
            label: 'Утилизатор',
            placeholder: 'Утилизатор',
            modelValue: 'utilizator',
            cols: ['col-md-4'],
            type: 'select',
            validation: { required },
            values: [
              {
                text: 'УтилПро',
                value: 1
              },
              {
                text: 'УтилМакс',
                value: 2
              }
            ]
          },
          {
            label: 'Номер акта утилизации',
            placeholder: '№',
            cols: ['col-md-4'],
            modelValue: 'actOfUtil',
            validation: { required }
          },
          {
            label: 'Дата отгрузки',
            placeholder: 'Дата отгрузки',
            modelValue: 'shippingDate',
            type: 'date',
            validation: { required }
          },
          {
            label: 'Сотрудник',
            placeholder: 'Сотрудник',
            modelValue: 'employee',
            type: 'select',
            validation: { required },
            values: [
              {
                text: 'Птушкин Александр',
                value: 1
              }
            ]
          }
        ],
        enableAddedFields: true,
        subtitle: 'Товары к утилизации',
        addedFields: [
          {
            label: 'Причина',
            placeholder: 'Причина',
            modelValue: 'reason',
            cols: ['col-md-6']
          },
          {
            label: 'Артикул товара',
            placeholder: 'Артикул',
            modelValue: 'art',
            cols: ['col-md-3']
          },
          {
            label: 'Кол-во',
            placeholder: '',
            type: 'number',
            modelValue: 'count',
            cols: ['col-md-3']
          }
        ]
      }
    }
  }
}
</script>
